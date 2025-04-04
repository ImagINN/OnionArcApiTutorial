using OnionArc.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath) // Dinamik olarak base path ayarlandý
    .AddJsonFile("appsettings.json", optional: false) // appsettings.json dosyasýný ekle ve her zaman eklemeli
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); // Ortam deðiþkenine göre appsettings dosyasýný ekle

builder.Services.AddPersistence(builder.Configuration); // Persistence katmanýný ekle. Konfigurasyon ayarladýktan sonraki satýrlara yazýlmalý

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
