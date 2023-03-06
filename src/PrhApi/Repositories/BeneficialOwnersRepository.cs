using System.Net;
using System.Text.Json;
using Amazon.S3;
using Amazon.S3.Model;
using PrhApi.Models.CodeGen.Model;
using PrhApi.Utils;

namespace PrhApi.Repositories;

internal class BeneficialOwnersRepository : IBeneficialOwnersRepository
{
    private readonly string _bucket;
    private readonly ILogger<BeneficialOwnersRepository> _logger;
    private readonly AmazonS3Client _s3Client;

    public BeneficialOwnersRepository(IConfiguration config, ILogger<BeneficialOwnersRepository> logger,
        AmazonS3Client s3Client)
    {
        _logger = logger;
        _s3Client = s3Client;
        _bucket = config.GetSection("PrhBucketName").Value ??
                  throw new InvalidOperationException("AWS bucket name key is missing");
    }

    public async Task<BeneficialOwnersResponse?> LoadAsync(
        string userId,
        string businessId,
        CancellationToken cancellationToken)
    {
        var key = S3ObjectKey.BeneficialOwnerKeyFrom(userId, businessId);

        try
        {
            var result = await LoadWithObjectKey(key);
            if (result is not null) return result;
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogInformation("{Message}", e.Message);
        }

        return null;
    }

    public async Task<BeneficialOwnersResponse> SaveAsync(
        string userId,
        string businessId,
        BeneficialOwnersWriteRequest details,
        CancellationToken cancellationToken)
    {
        var request = new PutObjectRequest
        {
            BucketName = _bucket,
            Key = S3ObjectKey.BeneficialOwnerKeyFrom(userId, businessId),
            ContentType = "application/json",
            ContentBody = JsonSerializer.Serialize(details.BeneficialOwners)
        };

        try
        {
            var response = await _s3Client.PutObjectAsync(request, cancellationToken);
            if (response.HttpStatusCode != HttpStatusCode.OK)
                _logger.LogError("Could not save company details to S3");
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }

        return details.BeneficialOwners;
    }

    private async Task<BeneficialOwnersResponse?> LoadWithObjectKey(string key)
    {
        var request = new GetObjectRequest
        {
            BucketName = _bucket,
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

        var responseObject = JsonSerializer.Deserialize<BeneficialOwnersResponse>(contents);
        return responseObject;
    }
}
