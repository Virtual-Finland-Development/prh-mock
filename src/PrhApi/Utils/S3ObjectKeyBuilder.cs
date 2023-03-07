namespace PrhApi.Utils;

public static class S3ObjectKey
{
    public static string GetBusinessIdFromS3ObjectKey(string key)
    {
        return key[(key.LastIndexOf("/", StringComparison.Ordinal) + 1)..^5];
    }

    public static string CompanyEstablishmentKeyFrom(string userId, string businessId)
    {
        return S3KeyFrom(userId, "establishment", businessId);
    }

    public static string BeneficialOwnerKeyFrom(string userId, string businessId)
    {
        return S3KeyFrom(userId, "beneficial-owner", businessId);
    }

    public static string SignatoryRightsKeyFrom(string userId, string businessId)
    {
        return S3KeyFrom(userId, "signatory-rights", businessId);
    }

    private static string S3KeyFrom(string userId, string dataProduct, string businessId)
    {
        if (userId is null || dataProduct is null || businessId is null)
            throw new ArgumentNullException(nameof(userId));

        return $"{dataProduct}/{userId}/{businessId}.json";
    }
}
