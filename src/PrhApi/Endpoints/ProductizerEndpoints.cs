using Microsoft.AspNetCore.Mvc;
using PrhApi.Models.CodeGen.Model;
using PrhApi.Services;
using PrhApi.Utils;
using PrhApi.Utils.Extensions;

namespace PrhApi.Endpoints;

public static class ProductizerEndpoints
{
    public static void MapProductizerEndpoints(this WebApplication app)
    {
        app.MapPost("productizer/NonListedCompany/Establishment",
            async ([FromBody] string businessId, [FromServices] ICompanyDetailsService service,
                [FromServices] IAuthenticationGatewayService authenticationGatewayService, HttpContext context) =>
            {
                await authenticationGatewayService.VerifyTokens(context.Request.Headers);

                var bearerTokenValue = context.Request.Headers.GetBearerTokenValue();
                var userId = TokenExtensions.ParseFromBearerToken(bearerTokenValue);

                var company = await service.LoadCompany(businessId);
                return company is null
                    ? Results.BadRequest($"Could not find company with businessId {businessId}")
                    : Results.Ok(company);
            }).Produces<EstablishmentResponse>();

        app.MapPost("productizer/NonListedCompany/Establishment/Write",
            async ([FromBody] EstablishmentResponse payload, [FromServices] ICompanyDetailsService service,
                [FromServices] IAuthenticationGatewayService authenticationGatewayService, HttpContext context) =>
            {
                await authenticationGatewayService.VerifyTokens(context.Request.Headers);

                // TODO: Get testbed user ID from authorization token
                var bearerTokenValue = context.Request.Headers.GetBearerTokenValue();
                var userId = TokenExtensions.ParseFromBearerToken(bearerTokenValue);

                var createdCompanyBusinessId = await service.CreateCompany(userId, payload);

                if (string.IsNullOrEmpty(createdCompanyBusinessId))
                    return Results.BadRequest($"Could not create company {payload.CompanyDetails.Name}");

                var result = await service.LoadCompany(createdCompanyBusinessId);

                return Results.Ok(result);
            }).Produces<EstablishmentResponse>().Produces<string>(400);

        app.MapPost("productizer/NonListedCompany/BeneficialOwners",
            async ([FromBody] string businessId, [FromServices] IBeneficialOwnersService service,
                [FromServices] IAuthenticationGatewayService authService,
                HttpContext context) =>
            {
                await authService.VerifyTokens(context.Request.Headers);
                var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                var result = await service.Load(userId, businessId, default);

                return result is null
                    ? Results.BadRequest($"Could not find beneficial owner data for company {businessId}")
                    : Results.Ok(result);
            }).Produces<BeneficialOwnersResponse>();

        app.MapPost("productizer/NonListedCompany/BeneficialOwners/Write",
                async ([FromBody] BeneficialOwnersWriteRequest payload, [FromServices] IBeneficialOwnersService service,
                    [FromServices] IAuthenticationGatewayService authService, HttpContext context) =>
                {
                    await authService.VerifyTokens(context.Request.Headers);
                    var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                    var data = await service.SaveOrUpdate(userId, payload.BusinessId, payload, default);

                    return data;
                })
            .Produces<BeneficialOwnersResponse>();

        app.MapPost("productizer/NonListedCompany/SignatoryRights",
            async ([FromBody] string businessId, [FromServices] ISignatoryRightsService service,
                [FromServices] IAuthenticationGatewayService authService, HttpContext context) =>
            {
                await authService.VerifyTokens(context.Request.Headers);
                var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                var data = await service.Load(userId, businessId, default);

                return data is null
                    ? Results.BadRequest($"Could not find signatory rights data for company {businessId}")
                    : Results.Ok(data);
            }).Produces<SignatoryRightsResponse>();

        app.MapPost("productizer/NonListedCompany/SignatoryRights/Write",
            async (SignatoryRightsWriteRequest payload, ISignatoryRightsService service,
                IAuthenticationGatewayService authService, HttpContext context) =>
            {
                await authService.VerifyTokens(context.Request.Headers);
                var userId = TokenExtensions.ParseFromBearerToken(context.Request.Headers.GetBearerTokenValue());

                var result = await service.SaveOrUpdate(userId, payload.BusinessId, payload, default);

                return result;
            }).Produces<SignatoryRightsResponse>();
    }
}
