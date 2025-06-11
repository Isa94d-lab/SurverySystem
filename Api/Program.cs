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

// Se agrega
using Api.Extensions;
// ---

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios

// New
builder.Services.AddAutoMapper(typeof(Api.Profiles.MappingProfiles).Assembly);
// ---

builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddOpenApi();

// Primero: registra la conexión a la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});

// Luego: agrega los servicios de infraestructura (repositorios, UoW, etc.)
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configura el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.MapControllers();


// Add
app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers()
   .RequireRateLimiting("ipLimiter");

// ---



app.Run();

// Este record es solo un ejemplo
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
