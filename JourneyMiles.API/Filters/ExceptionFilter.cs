using JourneyMiles.API.Shared.Communication.Responses;
using JourneyMiles.API.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
namespace JourneyMiles.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is AppException)
        {
            HandleAppException(context);
        }
        else
        {
            HandleUnknownException(context);
        }
    }
    private static void HandleAppException(ExceptionContext context)
    {
        if (context.Exception is UnauthorizedException)
        {
            var exception = (UnauthorizedException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new UnauthorizedObjectResult(
                new ErrorResponse(exception.Message));
        }
        if (context.Exception is ValidationException)
        {
            var exception = (ValidationException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(
                new ErrorResponse(exception.Errors));
        }
    }
    private static void HandleUnknownException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorResponse("UNKNOWN ERROR"));
    }
}
