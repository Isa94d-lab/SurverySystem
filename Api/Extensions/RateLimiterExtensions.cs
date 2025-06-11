using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Extensions;

namespace Api.Extensions
{
    // Clase estatica para crear metodos de extension (no se instancia)
    public static class RateLimiterExtensions
    {
        // Metodo de extension para IServiceCollection, nos permite registrar nuestra configuracion custom
        public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
        {
            // Registramos el middleware de Rate Limiting en el contenedor de servicios
            services.AddRateLimiter(options =>
            {
                // Que hacer si alguien se pasa del limite (lo bloqueamos y devolvemos mensaje)
                options.OnRejected = async (context, token) =>
                {
                    // Obtenemos la IP del cliente que fue bloqueado
                    var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida";

                    // Establecemos el codigo de estado HTTP a 429 (Too Many Requests)
                    context.HttpContext.Response.StatusCode = 429;

                    // Indicamos que la respuesta sera en formato JSON
                    context.HttpContext.Response.ContentType = "application/json";

                    // Armamos el mensaje de respuesta personalizado
                    var mensaje = $"{{\"message\": \"Demasiadas peticiones desde la IP {ip}. Intenta mas tarde.\"}}";

                    // Escribimos la respuesta al cliente
                    await context.HttpContext.Response.WriteAsync(mensaje, token);
                };

                // Definimos una politica llamada "ipLimiter" que limita por IP del cliente
                options.AddPolicy("ipLimiter", httpContext =>
                {
                    // Sacamos la IP del cliente actual (fallback a "unknown" si no se puede obtener)
                    var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                    // Retornamos una particion de rate limit basada en la IP
                    return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 5, // Maximo 5 peticiones permitidas...
                        Window = TimeSpan.FromSeconds(10), // ...cada 10 segundos
                        QueueLimit = 0, // No hacemos cola, si se pasa del limite se rechaza directo
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst // Si hubiera cola, se procesan primero los mas antiguos (aunque no aplica aqui)
                    });
                });
            });

            // Retornamos los servicios modificados para poder encadenar mas configuraciones
            return services;
        }
    }
}