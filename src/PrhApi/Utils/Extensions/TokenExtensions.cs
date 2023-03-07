using System.IdentityModel.Tokens.Jwt;

namespace PrhApi.Utils.Extensions;

public static class TokenExtensions
{
    public static string ParseFromBearerToken(string? bearerTokenValue)
    {
        return ParseJwtToken(bearerTokenValue).UserId;
    }

    /// <summary>
    ///     Parses the JWT token and returns the issuer and the user id
    /// </summary>
    private static (string UserId, string Issuer) ParseJwtToken(string? token)
    {
        if (string.IsNullOrEmpty(token)) throw new InvalidOperationException("No token provided");

        var issuer = GetTokenIssuer(token);
        var userId = GetTokenUserId(token);

        if (userId == null || issuer == null) throw new InvalidOperationException("The given token is not valid");

        return (userId, issuer);
    }

    private static JwtSecurityToken? GetSecurityToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        if (!handler.CanReadToken(token)) return null;

        var securityToken = handler.ReadJwtToken(token);
        return securityToken;
    }

    private static string? GetTokenUserId(string token)
    {
        var securityToken = GetSecurityToken(token);
        if (securityToken is null) return string.Empty;

        return string.IsNullOrEmpty(securityToken.Subject)
            ? securityToken.Claims.FirstOrDefault(o => o.Type == "userId")?.Value
            : securityToken.Subject;
    }

    private static string GetTokenIssuer(string token)
    {
        var securityToken = GetSecurityToken(token);
        return securityToken is null ? string.Empty : securityToken.Issuer;
    }
}
