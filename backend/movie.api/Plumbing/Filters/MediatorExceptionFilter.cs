using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FluentValidation;
using movie.application.Exceptions;

namespace movie.api.Plumbing.Filters;

public class MediatorExceptionFilter : ExceptionFilterAttribute
{
    private readonly IWebHostEnvironment _environment;

    public MediatorExceptionFilter(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        switch (exception)
        {
            case ValidationException ex:
                HandleValidationException(context, ex);
                break;
            case EntityNotFoundException:
                HandleEntityNotFoundException(context, exception);
                break;
            default:
                break;
        }
    }

    private static void HandleEntityNotFoundException(ExceptionContext context, Exception exception)
    {
        context.Result = new NotFoundResult();
    }

    private void HandleValidationException(ExceptionContext context, ValidationException exception)
    {
        var statusCode = (int)HttpStatusCode.BadRequest;
        var includeDebuggingInformation = !_environment.IsProduction();
        var details = includeDebuggingInformation ? exception.ToString() : null;
        var title = exception.Message;

        var errors = exception
            .Errors
            .GroupBy(failure => failure.PropertyName)
            .ToDictionary(failures => failures.Key, failures => failures.Select(failure => failure.ErrorMessage).ToArray());

        var problemDetails = new ValidationProblemDetails(errors)
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Title = title,
            Detail = details,
        };

        context.HttpContext.Response.StatusCode = statusCode;
        context.Result = new JsonResult(problemDetails);
    }
}