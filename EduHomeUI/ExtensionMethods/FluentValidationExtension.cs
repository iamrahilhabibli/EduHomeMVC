using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using FluentValidation.AspNetCore;

public static class FluentValidationExtensions
{
    public static void AddFluentValidationValidators(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(assembly);
    }
}
