using Microsoft.AspNetCore.Mvc.Filters;

namespace PrhApi.Utils.Attributes;

public class RequireConsentTokenAttribute : Attribute, IAuthorizationFilter
{
    private const string XConsentTokenKey = "x-consent-token";
    private readonly bool _requireConsentToken;

    public RequireConsentTokenAttribute(bool requireConsentToken = true)
    {
        _requireConsentToken = requireConsentToken;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!_requireConsentToken) return;
        if (!context.HttpContext.Request.Headers.ContainsKey(XConsentTokenKey))
            throw new InvalidOperationException("Consent token is missing");
    }
}
