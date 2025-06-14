using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Api.Extensions
{
    public static class AddApplicationServicesExtensions{
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()   //WithOrigins("https://dominio.com")
                    .AllowAnyMethod()          //WithMethods("GET","POST")()
                    .AllowAnyHeader());        //WithHeaders("accept","content-type"))
            });
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICategories_catalogRepository), typeof(Categories_catalogRepository));
            services.AddScoped(typeof(ICategories_catalogRepository), typeof(Category_optionsRepository));
        }

    }
}