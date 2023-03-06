using System.Net.Http.Headers;
using PrhApi.Utils;
using PrhApi.Utils.Extensions;

namespace PrhApi.Services;

public interface IAuthenticationGatewayService
{
    public Task VerifyTokens(IHeaderDictionary headers, bool requireConsentToken = false);
}

public class AuthenticationGatewayService : IAuthenticationGatewayService
{
    private readonly string _authenticationGatewayBaseUrl;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<AuthenticationGatewayService> _logger;

    public AuthenticationGatewayService(
        IHttpClientFactory httpClientFactory,
        ILogger<AuthenticationGatewayService> logger,
        IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _authenticationGatewayBaseUrl = config.GetSection("AuthGwBaseAddress").Value;
    }

    public async Task VerifyTokens(IHeaderDictionary headers, bool requireConsentToken = false)
    {
        try
        {
            var token = headers.GetBearerTokenValue();
            if (string.IsNullOrEmpty(token)) throw new InvalidOperationException("Token is missing");

            var httpClient = _httpClientFactory.CreateClient("auth-gw");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            httpClient.DefaultRequestHeaders.Add("x-authorization-context", "application-context-app-name");

            // TODO: This should be completely separate method
            if (requireConsentToken)
            {
                if (!headers.ContainsKey("x-consent-token"))
                    throw new InvalidOperationException("Consent token is missing");

                // Use header propagation instead
                httpClient.DefaultRequestHeaders.Add("x-consent-token", headers["x-consent-token"].ToString());
            }

            using var response = await httpClient.PostAsync($"{_authenticationGatewayBaseUrl}/authorize", null);
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
