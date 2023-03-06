namespace PrhApi.Utils.Extensions;

public static class HeaderExtension
{
    public static string? GetBearerTokenValue(this IHeaderDictionary headers)
    {
        var token = headers.Authorization.SingleOrDefault(x => x.Contains("Bearer"));
        return token?.Replace("Bearer", string.Empty).Trim();
    }
}
