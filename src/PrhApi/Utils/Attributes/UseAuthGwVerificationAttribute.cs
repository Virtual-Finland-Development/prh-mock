using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Filters;
using PrhApi.Utils.Extensions;

namespace PrhApi.Utils.Attributes;

public class UseAuthGwVerificationAttribute : Attribute, IAuthorizationFilter
{
    private const string XAuthorizationContext = "";
    private const string XApplicationContext = "";
    private const string XConsentTokenKey = "x-consent-token";

    private readonly bool _requireConsentToken;

    public UseAuthGwVerificationAttribute(bool requireConsentToken = true)
    {
        _requireConsentToken = requireConsentToken;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var httpClientFactory = context.HttpContext.RequestServices.GetService<IHttpClientFactory>();
        var logger = context.HttpContext.RequestServices.GetService<ILogger<UseAuthGwVerificationAttribute>>();
        var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
        try
        {
            var request = context.HttpContext.Request;
            var token = request.Headers.GetBearerTokenValue();

            var myToken = request.Headers.Authorization
                .ToList()
                .Single(x => x.Contains("Bearer"))
                .Replace("Bearer", string.Empty);

            var httpClient = httpClientFactory.CreateClient();

            var myOriginalToken = request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(myOriginalToken);
            httpClient.DefaultRequestHeaders.Add(XAuthorizationContext, XApplicationContext);

            if (_requireConsentToken)
                httpClient.DefaultRequestHeaders.Add(XConsentTokenKey, request.Headers[XConsentTokenKey].ToString());

            using var response = httpClient.PostAsync(configuration?["AuthGW:AuthorizeURL"], null).Result;
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            logger?.LogWarning("AuthGW could verify token");
            throw new InvalidOperationException(e.Message);
        }
        catch (ArgumentException e)
        {
            logger?.LogWarning("AuthGW could verify token");
            throw new InvalidOperationException(e.Message);
        }
    }
}
