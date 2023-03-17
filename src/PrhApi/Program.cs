using Amazon.S3;
using PrhApi.Endpoints;
using PrhApi.Repositories;
using PrhApi.Services;
using PrhApi.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddTransient<ICompanyDetailsService, CompanyDetailsService>();
builder.Services.AddTransient<ICompanyEstablishmentRepository, CompanyEstablishmentS3Repository>();

builder.Services.AddSingleton<ISignatoryRightsService, SignatoryRightsService>();
builder.Services.AddSingleton<ISignatoryRightsRepository, SignatoryRightsRepository>();

builder.Services.AddSingleton<IBeneficialOwnersService, BeneficialOwnersService>();
builder.Services.AddSingleton<IBeneficialOwnersRepository, BeneficialOwnersRepository>();

builder.Services.AddSingleton<IAuthenticationGatewayService, AuthenticationGatewayService>();
builder.Services.AddSingleton<AmazonS3Client>();

builder.Services.AddHttpClient<IAuthenticationGatewayService, AuthenticationGatewayService>(options =>
{
    options.BaseAddress = options.BaseAddress = new Uri(
        builder.Configuration.GetSection("AuthGwBaseAddress").Value
        ?? throw new InvalidOperationException("Missing configuration value for Auth GW API base address"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.CustomSchemaIds(type => type.ToString()); });


builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (VirtualFinlandEnvironments.IsDevelopment(app.Environment) || VirtualFinlandEnvironments.IsStaging(app.Environment))
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapCompanyEndpoints();
app.MapProductizerEndpoints();

app.Run();
