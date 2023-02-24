namespace PrhApi.Services;

public static class S3ObjectKeyBuilder
{
    public static string Build(Guid userId, string businessId)
    {
        if (businessId is null) throw new ArgumentNullException(nameof(businessId));

        return $"{userId}/establishment/{businessId}.json";
    }

    public static string Build(Guid userId)
    {
        return $"{userId}/establishment/";
    }
}

public static class S3ObjectKey
{
    public static string BuildFrom(Guid userId, string businessId)
    {
        if (businessId is null) throw new ArgumentNullException(nameof(businessId));

        return $"{userId}/establishment/{businessId}.json";
    }

    public static string GetBusinessIdFromS3ObjectKey(string key)
    {
        return key[(key.LastIndexOf("/", StringComparison.Ordinal) + 1)..^5];
    }

    public static string GetEstablishmentPrefix(Guid userId)
    {
        return $"{userId}/establishment/";
    }
}
