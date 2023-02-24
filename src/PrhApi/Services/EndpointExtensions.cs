using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Services;

public static class EndpointExtensions
{
    public static void RegisterProductizerEndpoints(this WebApplication app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.MapGet("productizer/NonListedCompany/Establishment",
            (EstablishmentResponse request) => { return Task.FromResult(Results.Ok("Establishment Ok")); });

        app.MapGet("productizer/NonListedCompany/BeneficialOwner",
            () => Task.FromResult(Results.Ok("BeneficialOwner Ok")));
        app.MapGet("productizer/NonListedCompany/SignatoryRights",
            () => Task.FromResult(Results.Ok("SignatoryRights Ok")));
    }
}
