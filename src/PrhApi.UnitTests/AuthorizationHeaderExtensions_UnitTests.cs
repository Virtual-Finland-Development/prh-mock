using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using PrhApi.Utils;
using PrhApi.Utils.Extensions;

namespace PrhApi.UnitTests;

// ReSharper disable once InconsistentNaming
public class AuthorizationHeaderExtensions_UnitTests
{
    [Test]
    public void TryingToGetBearerTokenValueFromHeaders_WithSingleAuthorizationValue_ReturnsString()
    {
        IHeaderDictionary headers = new HeaderDictionary();
        headers.Add("Authorization", new StringValues("Bearer ABC"));

        var result = headers.GetBearerTokenValue();

        result.Should<string>().BeEquivalentTo("ABC");
    }

    [Test]
    public void TryingToGetBearerTokenValueFromHeaders_WithMultipleAuthorizationValues_ReturnsString()
    {
        IHeaderDictionary headers = new HeaderDictionary();
        headers.Add("Authorization", new StringValues(new[] { "Bearer ABC", "Basic XYZ" }));

        var result = headers.GetBearerTokenValue();

        result.Should<string>().BeEquivalentTo("ABC");
    }

    [Test]
    public void TryingToGetBearerTokenValueFromHeaders_WithNoAuthorizationValues_ShouldReturnNull()
    {
        IHeaderDictionary headers = new HeaderDictionary();
        headers.Add("Authorization", new StringValues());

        var result = headers.GetBearerTokenValue();
        
        result.Should<string>().BeNull();
    }
}
