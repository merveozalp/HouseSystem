using BuildingSystem.UI.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingSystem.UI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();

            return services;
        }

        public static IMvcBuilder AddWebCore(this IMvcBuilder builder)
        {
            builder.AddMvcOptions(options => options.Filters.Add<ModelStateFilterAttribute>());
            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            return builder;
        }
    }
}
