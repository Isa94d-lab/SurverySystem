using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Infrastructure.UnitOfWork;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork.UnitOfWork>();
            services.AddScoped<ICategories_catalogRepository, Categories_catalogRepository>();
            services.AddScoped<ICategory_optionsRepository, Category_optionsRepository>();
            services.AddScoped<IChaptersRepository, ChaptersRepository>();
        }
    }
}
