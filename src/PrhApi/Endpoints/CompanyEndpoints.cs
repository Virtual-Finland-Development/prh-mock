using PrhApi.Models.CodeGen.Model;
using PrhApi.Services;

namespace PrhApi.Endpoints;

public static class CompanyEndpoints
{
    public static void MapCompanyEndpoints(this WebApplication app)
    {
        app.MapGet("companies", GetAllCompanies);
        app.MapGet("companies/{businessId}", GetCompanyDetails).Produces<EstablishmentResponse>().Produces(404);
        app.MapGet("users/{userId:guid}/companies", GetAllUserCompanies);
        app.MapPost("users/{userId:guid}/companies", CreateCompany);
        app.MapMethods("users/{userId:guid}/companies/{businessId}", new[] { "PATCH" }, UpdateCompany).Produces(204);
        app.MapDelete("users/{userId:guid}/companies/{businessId}", DeleteCompany).Produces(204);
    }

    private static async Task<IResult> GetAllCompanies(ICompanyDetailsService service)
    {
        var companies = await service.LoadCompanies();
        return Results.Ok(companies);
    }

    private static async Task<IResult> GetCompanyDetails(string businessId, ICompanyDetailsService service)
    {
        var company = await service.LoadCompany(businessId);
        return company is null ? Results.NotFound() : Results.Ok(company);
    }

    private static async Task<IResult> GetAllUserCompanies(Guid userId, ICompanyDetailsService service)
    {
        var companies = await service.GetUserCompanies(userId);
        return Results.Ok(companies);
    }

    private static async Task<IResult> CreateCompany(Guid userId, EstablishmentResponse details,
        ICompanyDetailsService service)
    {
        var businessId = await service.CreateCompany(userId, details);
        return Results.Ok(businessId);
    }

    private static async Task<IResult> UpdateCompany(Guid userId, string businessId, EstablishmentResponse details,
        ICompanyDetailsService service)
    {
        await service.SaveOrUpdateCompany(userId, businessId, details);
        return Results.NoContent();
    }

    private static async Task DeleteCompany(Guid userId, string businessId, ICompanyDetailsService service)
    {
        await service.DeleteCompany(userId, businessId);
    }
}
