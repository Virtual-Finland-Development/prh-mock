using System.Net.Http.Headers;
using PrhApi.Utils.Extensions;

namespace PrhApi.Services;

public interface IAuthenticationGatewayService
{
    public Task VerifyTokens(IHeaderDictionary headers, bool requireConsentToken = false);
}

public class AuthenticationGatewayService : IAuthenticationGatewayService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AuthenticationGatewayService> _logger;

    public AuthenticationGatewayService(HttpClient httpClient, ILogger<AuthenticationGatewayService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task VerifyTokens(IHeaderDictionary headers, bool requireConsentToken = false)
    {
        try
        {
            var token = headers.GetBearerTokenValue();
            if (string.IsNullOrEmpty(token)) throw new InvalidOperationException("Token is missing");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            _httpClient.DefaultRequestHeaders.Add("x-authorization-context", "application-context-app-name");

            // TODO: This should be completely separate method
            if (requireConsentToken)
            {
                if (!headers.ContainsKey("x-consent-token"))
                    throw new InvalidOperationException("Consent token is missing");

                // Use header propagation instead
                _httpClient.DefaultRequestHeaders.Add("x-consent-token", headers["x-consent-token"].ToString());
            }

            using var response = await _httpClient.PostAsync("/authorize", null);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            _logger.LogInformation("NotAuthorizedException: {Message}", e.Message);
            throw;
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation("NotAuthorizedException: {Message}", e.Message);
        }
    }
}
