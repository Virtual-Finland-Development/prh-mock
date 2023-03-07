using System.Net;
using System.Text.Json;
using Amazon.S3;
using Amazon.S3.Model;
using PrhApi.Models.CodeGen.Model;
using PrhApi.Utils;

namespace PrhApi.Repositories;

public class CompanyEstablishmentS3Repository : ICompanyEstablishmentRepository
{
    private readonly ILogger<CompanyEstablishmentS3Repository> _logger;
    private readonly string _prhBucketName;
    private readonly AmazonS3Client _s3Client;

    public CompanyEstablishmentS3Repository(
        AmazonS3Client s3Client,
        ILogger<CompanyEstablishmentS3Repository> logger,
        IConfiguration configuration)
    {
        _s3Client = s3Client;
        _logger = logger;
        _prhBucketName = configuration.GetSection("PrhBucketName").Value ??
                         throw new InvalidOperationException("AWS bucket name key is missing");
    }

    public async Task<EstablishmentResponse?> LoadWithKey(string key)
    {
        return await LoadWithObjectKey(key);
    }

    public async Task<EstablishmentResponse?> LoadWithBusinessId(string businessId)
    {
        var response = await _s3Client.ListObjectsV2Async(new ListObjectsV2Request
        {
            BucketName = _prhBucketName,
            Prefix = "establishment/"
        });

        var result = response.S3Objects
            .SingleOrDefault(x => S3ObjectKey.GetBusinessIdFromS3ObjectKey(x.Key) == businessId);

        if (result is null) return null;

        return await LoadWithObjectKey(result.Key);
    }

    public async Task<string> Save(string userId, string businessId, EstablishmentResponse details)
    {
        var request = new PutObjectRequest
        {
            BucketName = _prhBucketName,
            Key = S3ObjectKey.CompanyEstablishmentKeyFrom(userId, businessId),
            ContentType = "application/json",
            ContentBody = JsonSerializer.Serialize(details)
        };
        request.Metadata.Add("company-name", details.CompanyDetails.Name);

        try
        {
            var response = await _s3Client.PutObjectAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK)
                _logger.LogError("Could not save company details to S3");
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }

        return businessId;
    }

    public async Task<List<EstablishmentResponse>> LoadUserCompanies(string userId)
    {
        var listObjectsRequest = new ListObjectsV2Request
        {
            BucketName = _prhBucketName,
            Prefix = $"establishment/{userId}/"
        };

        // TODO: Result only shows first 1000 entries without loop of some sort
        var result = await _s3Client.ListObjectsV2Async(listObjectsRequest);
        var keys = result.S3Objects.Select(s3Object => s3Object.Key).ToList();

        var companies = new List<EstablishmentResponse>();

        foreach (var key in keys)
        {
            var company = await LoadWithObjectKey(key);
            if (company is null) continue;
            companies.Add(company);
        }

        return companies;
    }

    public async Task<List<MinimalCompanyDetails>> LoadAll()
    {
        var response = await _s3Client.ListObjectsV2Async(new ListObjectsV2Request
        {
            BucketName = _prhBucketName,
            Prefix = "establishment/"
        });

        var result = response.S3Objects.Select(o => new MinimalCompanyDetails
        {
            BusinessId = S3ObjectKey.GetBusinessIdFromS3ObjectKey(o.Key),
            Key = o.Key
        }).ToList();

        return result;
    }

    public async Task<Task> Delete(string userId, string businessId)
    {
        var request = new DeleteObjectRequest
        {
            BucketName = _prhBucketName,
            Key = S3ObjectKey.CompanyEstablishmentKeyFrom(userId, businessId)
        };

        try
        {
            await _s3Client.DeleteObjectAsync(request);
        }
        catch (AmazonS3Exception e)
        {
            await Task.FromException<AmazonS3Exception>(e);
        }

        return Task.CompletedTask;
    }

    private async Task<EstablishmentResponse?> LoadWithObjectKey(string key)
    {
        var request = new GetObjectRequest
        {
            BucketName = _prhBucketName,
            Key = key
        };

        string contents;
        try
        {
            using var response = await _s3Client.GetObjectAsync(request);
            using var streamReader = new StreamReader(response.ResponseStream);
            contents = await streamReader.ReadToEndAsync();
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogInformation("Json file with key {Key} not found. Message: {Message}", key, e.Message);
            throw;
        }

        var responseObject = JsonSerializer.Deserialize<EstablishmentResponse>(contents);
        return responseObject;
    }
}
