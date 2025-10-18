using Microsoft.Extensions.DependencyInjection;
using OnionProjectSystem.Application.Exceptions;
using System.Reflection;
using FluentValidation;
using MediatR;
using OnionProjectSystem.Application.Beheviors;
using OnionProjectSystem.Application.Features.Products.Rules;
using OnionProjectSystem.Application.Bases;
namespace OnionProjectSystem.Application
{
    public static class ApplicationRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }

       private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(type) && type!=t).ToList();

            foreach (var t in types)
            {
                services.AddTransient(t);
            }

            return services;
        }
    }
}
