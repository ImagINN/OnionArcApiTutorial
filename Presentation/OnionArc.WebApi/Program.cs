using OnionArc.Application;
using OnionArc.Application.Exceptions;
using OnionArc.Infrastructure;
using OnionArc.Mapper;
using OnionArc.Persistence;
using Microsoft.OpenApi.Models;

// BU BÝR DENEMEDÝR
// Bu da deneme child.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor(); // HttpContext'i Dependency Injection ile kullanabilmek için eklenir
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // IHttpContextAccessor arayüzünü uygulayan bir sýnýf eklenir

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath) // Dinamik olarak base path ayarlandý
    .AddJsonFile("appsettings.json", optional: false) // appsettings.json dosyasýný ekle ve her zaman eklemeli
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); // Ortam deðiþkenine göre appsettings dosyasýný ekle

builder.Services.AddPersistence(builder.Configuration); // Persistence katmanýný ekle. Konfigurasyon ayarladýktan sonraki satýrlara yazýlmalý
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnionArc API", Version = "v1", Description = "OnionArc API Tutorial Swagger Client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    c.CustomSchemaIds(type => type.FullName); // Swagger'da her model için benzersiz bir isim oluþturur
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
