using System;
using System.Reflection;
using Api.Profiles;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure;
using Api.Extensions;

// Necesario para configurar el rate limiting
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// ------------------- CONFIGURACIÓN DE SERVICIOS -------------------

// Registro de AutoMapper indicando el assembly donde están los perfiles de mapeo
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// Configura el sistema de rate limiting definido en la clase de extensión personalizada
builder.Services.AddCustomRateLimiter();

// Habilita CORS usando la política definida en ConfigureCors (en Api/Extensions/CorsServiceExtension.cs)
builder.Services.ConfigureCors();

// Registra los controladores
builder.Services.AddControllers();

// Agrega servicios de la capa de aplicación (Application Layer)
builder.Services.AddApplicationServices();

// Agrega la documentación Swagger y configuración relacionada
builder.Services.AddOpenApi();

// Registro del contexto de base de datos con PostgreSQL (cadena en appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});

// Agrega los servicios de la capa de infraestructura (repositorios, unit of work, etc.)
builder.Services.AddInfrastructure();

// ------------------- CONFIGURACIÓN DEL PIPELINE HTTP -------------------

var app = builder.Build();

// Si el entorno es desarrollo, habilita Swagger y la documentación interactiva
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();       // Mapea la documentación OpenAPI
    app.UseSwagger();       // Habilita el middleware de Swagger
    app.UseSwaggerUI();     // Habilita la interfaz web de Swagger
}

// Habilita el uso de CORS con la política definida
app.UseCors("CorsPolicy");

// Redirecciona automáticamente las peticiones HTTP a HTTPS
app.UseHttpsRedirection();

// Habilita el middleware global de Rate Limiting
app.UseRateLimiter();

// Habilita la autorización (esto prepara el terreno)
app.UseAuthorization();

// Mapea los endpoints de los controladores y les aplica la política "ipLimiter"
app.MapControllers()
   .RequireRateLimiting("ipLimiter"); // Aplica la política de rate limiting por IP a todos los endpoints

// Corre la aplicación
app.Run();


// Este record es solo un ejemplo y no afecta al sistema actual
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
