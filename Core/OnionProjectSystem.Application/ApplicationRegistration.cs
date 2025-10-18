using Microsoft.Extensions.DependencyInjection;
using OnionProjectSystem.Application.Exceptions;
using System.Reflection;
using FluentValidation;
using MediatR;
using OnionProjectSystem.Application.Beheviors;
namespace OnionProjectSystem.Application
{
    public static class ApplicationRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}
