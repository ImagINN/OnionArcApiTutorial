using OnionArc.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath) // Dinamik olarak base path ayarland�
    .AddJsonFile("appsettings.json", optional: false) // appsettings.json dosyas�n� ekle ve her zaman eklemeli
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); // Ortam de�i�kenine g�re appsettings dosyas�n� ekle

builder.Services.AddPersistence(builder.Configuration); // Persistence katman�n� ekle. Konfigurasyon ayarlad�ktan sonraki sat�rlara yaz�lmal�

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
