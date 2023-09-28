using Microsoft.AspNetCore.Mvc;
using PrhApi.Models.CodeGen.Model;
using PrhApi.Services;
using PrhApi.Utils.Extensions;

namespace PrhApi.Endpoints;

public static class ProductizerEndpoints
{
    public static void MapProductizerEndpoints(this WebApplication app)
    {
        app.MapPost("NSG/Agent/LegalEntity/NonListedCompany/Establishment_v1.0",
            async ([FromBody] EstablishmentRequest request, [FromServices] ICompanyDetailsService service,
                [FromServices] IAuthenticationGatewayService authenticationGatewayService, HttpContext context) =>
            {
                await authenticationGatewayService.VerifyTokens(context.Request.Headers);

                var company = await service.LoadCompany(request.NationalIdentifier);
                return company is null
                    ? Results.NotFound($"Could not find company with national identifier: {request.NationalIdentifier}")
                    : Results.Ok(company);
            }).Produces<EstablishmentResponse>().Produces(404);

        app.MapPost("NSG/Agent/LegalEntity/NonListedCompany/Establishment/Write_v1.0",
            async ([FromBody] EstablishmentResponse payload, [FromServices] ICompanyDetailsService service,
                [FromServices] IAuthenticationGatewayService authenticationGatewayService, HttpContext context) =>
            {
                await authenticationGatewayService.VerifyTokens(context.Request.Headers);

                var bearerTokenValue = context.Request.Headers.GetBearerTokenValue();
                var userId = TokenExtensions.ParseFromBearerToken(bearerTokenValue);

                var createdCompanyBusinessId = await service.CreateCompany(userId, payload);

                if (string.IsNullOrEmpty(createdCompanyBusinessId))
                    return Results.BadRequest($"Could not create company {payload.CompanyDetails.Name}");

                var result = await service.LoadCompany(createdCompanyBusinessId);

                return Results.Ok(result);
            }).Produces<EstablishmentResponse>().Produces<string>(400);

        app.MapPost("NSG/Agent/LegalEntity/NonListedCompany/BeneficialOwners_v1.0",
            async ([FromBody] BeneficialOwnersRequest request, [FromServices] IBeneficialOwnersService service,
                [FromServices] IAuthenticationGatewayService authService,
                HttpContext context) =>
            {
                await authService.VerifyTokens(context.Request.Headers);
                var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                var result = await service.Load(userId, request.NationalIdentifier, default);

                return result is null
                    ? Results.NotFound($"Could not find beneficial owner data for company {request.NationalIdentifier}")
                    : Results.Ok(result);
            }).Produces<BeneficialOwnersResponse>().Produces(404);

        app.MapPost("NSG/Agent/LegalEntity/NonListedCompany/BeneficialOwners/Write_v1.0",
                async ([FromBody] BeneficialOwnersWriteRequest payload, [FromServices] IBeneficialOwnersService service,
                    [FromServices] IAuthenticationGatewayService authService, HttpContext context) =>
                {
                    await authService.VerifyTokens(context.Request.Headers);
                    var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                    var data = await service.SaveOrUpdate(userId, payload.NationalIdentifier, payload, default);

                    return data;
                })
            .Produces<BeneficialOwnersResponse>();

        app.MapPost("NSG/Agent/LegalEntity/NonListedCompany/SignatoryRights_v1.0",
            async ([FromBody] SignatoryRightsRequest request, [FromServices] ISignatoryRightsService service,
                [FromServices] IAuthenticationGatewayService authService, HttpContext context) =>
            {
                await authService.VerifyTokens(context.Request.Headers);
                var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                var data = await service.Load(userId, request.NationalIdentifier, default);

                return data is null
                    ? Results.NotFound($"Could not find signatory rights data for company {request.NationalIdentifier}")
                    : Results.Ok(data);
            }).Produces<SignatoryRightsResponse>().Produces(404);

        app.MapPost("NSG/Agent/LegalEntity/NonListedCompany/SignatoryRights/Write_v1.0",
            async (SignatoryRightsWriteRequest payload, ISignatoryRightsService service,
                IAuthenticationGatewayService authService, HttpContext context) =>
            {
                await authService.VerifyTokens(context.Request.Headers);
                var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                var result = await service.SaveOrUpdate(userId, payload.NationalIdentifier, payload, default);

                return result;
            }).Produces<SignatoryRightsResponse>();

        app.MapPost("NSG/Agent/BasicInformation_v1.0",
            async ([FromBody] BasicInformationRequest request, [FromServices] ICompanyDetailsService service, HttpContext context) =>
            {
                var companyBasicInfo = await service.LoadCompanyBasicInformation(request.NationalIdentifier);
                if (companyBasicInfo is null)
                    return Results.NotFound($"Could not find company with national identifier: {request.NationalIdentifier}");

                return Results.Ok(companyBasicInfo);
            }).Produces<BasicInformationResponse>().Produces(404);
    }
}
