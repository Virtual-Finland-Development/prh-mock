using PrhApi.Models.CodeGen.Model;
using PrhApi.Services;

namespace PrhApi.Endpoints;

public static class CompanyEndpoints
{
    public static void MapCompanyEndpoints(this WebApplication app)
    {
        app.MapGet("companies", GetAllCompanies);
        app.MapGet("companies/{businessId}", GetCompanyDetails).Produces<EstablishmentResponse>().Produces(404);
        app.MapGet("users/{userId}/companies", GetAllUserCompanies);
        app.MapPost("users/{userId}/companies", CreateCompany);
        app.MapMethods("users/{userId}/companies/{businessId}", new[] { "PATCH" }, UpdateCompany).Produces(204);
        app.MapDelete("users/{userId}/companies/{businessId}", DeleteCompany).Produces(204);
    }

    private static async Task<IResult> GetAllCompanies(ICompanyDetailsService service)
    {
        var companies = await service.LoadCompanies();
        return Results.Ok(companies);
    }

    private static async Task<IResult> GetCompanyDetails(string businessId, ICompanyDetailsService service)
    {
        //TODO: Fix this
        var company = await service.LoadCompany(businessId);
        return company is null ? Results.NotFound() : Results.Ok(company);
    }

    private static async Task<IResult> GetAllUserCompanies(string userId, ICompanyDetailsService service)
    {
        var companies = await service.GetUserCompanies(userId);
        return Results.Ok(companies);
    }

    private static async Task<IResult> CreateCompany(string userId, EstablishmentResponse details,
        ICompanyDetailsService service)
    {
        var businessId = await service.CreateCompany(userId, details);
        return Results.Ok(businessId);
    }

    private static async Task<IResult> UpdateCompany(string userId, string businessId, EstablishmentResponse details,
        ICompanyDetailsService service)
    {
        await service.SaveOrUpdateCompany(userId, businessId, details);
        return Results.NoContent();
    }

    private static async Task DeleteCompany(string userId, string businessId, ICompanyDetailsService service)
    {
        await service.DeleteCompany(userId, businessId);
    }
}
