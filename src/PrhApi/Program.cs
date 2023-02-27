using Amazon.S3;
using PrhApi.Endpoints;
using PrhApi.Repositories;
using PrhApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddTransient<ICompanyDetailsService, CompanyDetailsService>();
builder.Services.AddTransient<ICompanyEstablishmentRepository, CompanyEstablishmentS3Repository>();
builder.Services.AddTransient<AmazonS3Client>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.CustomSchemaIds(type => type.ToString()); });


builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
