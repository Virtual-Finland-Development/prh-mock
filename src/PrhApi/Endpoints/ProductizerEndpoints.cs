using PrhApi.Models.CodeGen.Model;
using PrhApi.Services;

namespace PrhApi.Endpoints;

public static class ProductizerEndpoints
{
    public static void MapProductizerEndpoints(this WebApplication app)
    {
        // Here we assume y-tunnus will be posted in requests body
        app.MapPost("productizer/NonListedCompany/Establishment",
            async (string businessId, ICompanyDetailsService service) =>
            {
                var company = await service.LoadCompany(businessId);
                return Results.Ok(company);
            }).Produces<EstablishmentResponse>();

        app.MapPost("productizer/NonListedCompany/Establishment/Write", (EstablishmentResponse data) =>
        {
            // TODO: Get user ID from token and call service.CreateCompany with correct user ID
            throw new NotImplementedException();
        }).Produces<EstablishmentResponse>();

        app.MapPost("productizer/NonListedCompany/BeneficialOwners", () =>
        {
            // TODO: Implementation missing
            throw new NotImplementedException();
        }).Produces<BeneficialOwnersResponse>();

        app.MapPost("productizer/NonListedCompany/BeneficialOwners/Write", (BeneficialOwnersResponse data) =>
        {
            // TODO: Implementation missing
            throw new NotImplementedException();
        }).Produces<BeneficialOwnersResponse>();

        app.MapPost("productizer/NonListedCompany/SignatoryRights", () =>
        {
            // TODO: Implementation missing
            throw new NotImplementedException();
        }).Produces<SignatoryRightsResponse>();

        app.MapPost("productizer/NonListedCompany/SignatoryRights/Write", (SignatoryRightsResponse data) =>
        {
            // TODO: Implementation missing
            throw new NotImplementedException();
        }).Produces<SignatoryRightsResponse>();
    }
}
