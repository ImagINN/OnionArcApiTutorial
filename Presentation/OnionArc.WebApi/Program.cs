using OnionArc.Application;
using OnionArc.Application.Exceptions;
using OnionArc.Infrastructure;
using OnionArc.Mapper;
using OnionArc.Persistence;
using Microsoft.OpenApi.Models;

// BU B�R DENEMED�R
// Bu da deneme child.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor(); // HttpContext'i Dependency Injection ile kullanabilmek i�in eklenir
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // IHttpContextAccessor aray�z�n� uygulayan bir s�n�f eklenir

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath) // Dinamik olarak base path ayarland�
    .AddJsonFile("appsettings.json", optional: false) // appsettings.json dosyas�n� ekle ve her zaman eklemeli
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); // Ortam de�i�kenine g�re appsettings dosyas�n� ekle

builder.Services.AddPersistence(builder.Configuration); // Persistence katman�n� ekle. Konfigurasyon ayarlad�ktan sonraki sat�rlara yaz�lmal�
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
    c.CustomSchemaIds(type => type.FullName); // Swagger'da her model i�in benzersiz bir isim olu�turur
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
