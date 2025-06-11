using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Infrastructure.UnitOfWork;
using Infrastructure.Repositories;
using Domain.Entities;

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
            services.AddScoped<IOption_questionsRepository, Option_questionsRepository>();
            services.AddScoped<IOptions_responseRepository, Options_responseRepository>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            services.AddScoped<ISub_questionsRepository, Sub_questionsRepository>();
            services.AddScoped<ISumaryoptionsRepository, SumaryoptionsRepository>();
            services.AddScoped<ISurveysRepository, SurveysRepository>();

        }
    }
}
