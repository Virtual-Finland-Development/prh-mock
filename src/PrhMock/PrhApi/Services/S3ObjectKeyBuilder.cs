namespace company_establishment_api.Controllers;

public static class S3ObjectKeyBuilder
{
    public static string Build(Guid userId, string businessId)
    {
        if (businessId is null) throw new ArgumentNullException(nameof(businessId));

        return $"{userId}/company-details/{businessId}.json";
    }

    public static string Build(Guid userId)
    {
        return $"{userId}/company-details/";
    }
}
