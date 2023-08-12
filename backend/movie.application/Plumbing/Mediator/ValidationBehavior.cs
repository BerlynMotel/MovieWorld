using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace movie.application.Plumbing.Mediator;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IServiceProvider _serviceProvider;
    public ValidationBehavior(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestType = request.GetType();
        var validatorType = typeof(IValidator<>).MakeGenericType(requestType);

        var scope = _serviceProvider.CreateScope();
        IValidator? validator = scope!.ServiceProvider.GetService(validatorType) as IValidator;
        if (validator == null)
        {
            return await next();
        }

        var result = await validator.ValidateAsync(new ValidationContext<TRequest>(request), cancellationToken);
        if (result.IsValid)
        {
            return await next();
        }

        throw new ValidationException(result.Errors);
    }
}

