using System.Net;
using System.Text.Json;
using Amazon.S3;
using Amazon.S3.Model;

namespace company_establishment_api.Controllers;

public class CompanyDetailsRepository : ICompanyDetailsRepository
{
    private readonly ILogger<CompanyDetailsRepository> _logger;
    private readonly string _prhBucketName;
    private readonly AmazonS3Client _s3Client;

    public CompanyDetailsRepository(AmazonS3Client s3Client, ILogger<CompanyDetailsRepository> logger,
        IConfiguration configuration)
    {
        _s3Client = s3Client;
        _logger = logger;
        _prhBucketName = configuration.GetSection("Aws:PrhBucketName").Value ??
                         throw new InvalidOperationException("AWS bucket name key is missing");
    }

    /*
    
       format of the data should be
       {user-id}/company-details/{document-id}.json
       
       user-id = uuid of the user who created the company
       document-id = business ID
    
    */

    public async Task<CompanyDetails?> LoadWithKey(string key)
    {
        return await LoadWithObjectKey(key);
    }

    public async Task<CompanyDetails?> LoadWithBusinessId(string businessId)
    {
        var response = await _s3Client.ListObjectsV2Async(new ListObjectsV2Request { BucketName = _prhBucketName });
        var result = response.S3Objects.SingleOrDefault(x => x.Key.Contains(businessId));

        if (result is null) return null;

        return await LoadWithObjectKey(result.Key);
    }

    public async Task<string?> Save(Guid userId, CompanyDetails details)
    {
        var request = new PutObjectRequest
        {
            BucketName = _prhBucketName,
            Key = S3ObjectKeyBuilder.Build(userId, details.BusinessId),
            ContentType = "application/json",
            ContentBody = JsonSerializer.Serialize(details)
        };

        try
        {
            var response = await _s3Client.PutObjectAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK)
                _logger.LogError("Could not save company details to S3");
        }
        catch (AmazonS3Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return details.BusinessId;
    }

    public async Task<List<CompanyDetails>> LoadUserCompanies(Guid userId)
    {
        var listObjectsRequest = new ListObjectsV2Request
        {
            BucketName = _prhBucketName,
            Prefix = $"{userId}/company-details/"
        };

        // TODO: Result only shows first 1000 entries without loop of some sort
        var result = await _s3Client.ListObjectsV2Async(listObjectsRequest);
        var keys = result.S3Objects.Select(s3Object => s3Object.Key).ToList();

        var companies = new List<CompanyDetails>();

        foreach (var key in keys)
        {
            var company = await LoadWithObjectKey(key);
            if (company is null) continue;
            companies.Add(company);
        }

        return companies;
    }

    private async Task<CompanyDetails?> LoadWithObjectKey(string key)
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
            if (response.HttpStatusCode != HttpStatusCode.OK)
            {
                _logger.LogInformation("Json file with key {Key} not found", key);
                return null;
            }

            using var streamReader = new StreamReader(response.ResponseStream);
            contents = await streamReader.ReadToEndAsync();
        }
        catch (AmazonS3Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        var responseObject = JsonSerializer.Deserialize<CompanyDetails>(contents);
        return responseObject;
    }
}
