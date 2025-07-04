using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependecyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>{
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });
        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
        return services;
    }
}