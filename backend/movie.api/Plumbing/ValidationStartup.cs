using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace movie.api.Plumbing;

public static class ValidationStartup
{
    public static void AddCustomValidator(this IServiceCollection services, Assembly assemblyScope)
    {
        services.AddFluentValidationAutoValidation()
        .AddFluentValidationClientsideAdapters().AddValidatorsFromAssembly(assemblyScope);
    }
}