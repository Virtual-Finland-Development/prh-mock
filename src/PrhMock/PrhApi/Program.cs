using Amazon.S3;
using company_establishment_api.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddTransient<ICompanyDetailsService, CompanyDetailsService>();
builder.Services.AddTransient<ICompanyDetailsRepository, CompanyDetailsRepository>();
builder.Services.AddTransient<AmazonS3Client>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("companies/{businessId}", async (string businessId, ICompanyDetailsService service) =>
{
    var company = await service.LoadCompany(businessId);
    return company is null ? Results.NotFound() : Results.Ok(company);
}).Produces<CompanyDetails>().Produces(404);

app.MapGet("users/{userId:guid}/companies", async (Guid userId, ICompanyDetailsService service) =>
{
    var companies = await service.GetUserCompanies(userId);
    return Results.Ok(companies);
}).Produces(200);

app.MapPost("users/{userId:guid}/companies",
    async (Guid userId, CompanyDetails details, ICompanyDetailsService service) =>
    {
        var businessId = await service.CreateCompany(userId, details);
        return Results.Ok(businessId);
    }).Produces<string>().Produces(500);

app.MapPatch("users/{userId:guid}/companies/{businessId}",
    async (Guid userId, string businessId, CompanyDetails details, ICompanyDetailsService service) =>
    {
        var result = await service.SaveOrUpdateCompany(userId, businessId, details);
        return Results.Ok(result);
    }).Produces(200).Produces(500);

app.Run();
