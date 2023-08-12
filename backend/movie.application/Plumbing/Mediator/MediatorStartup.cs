using MediatR;
using Microsoft.Extensions.DependencyInjection;
using movie.application.Abstractions.Commands;

namespace movie.application.Plumbing.Mediator;

public static class MediatorStartup
{
    public static void AddCustomMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ICommand));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
