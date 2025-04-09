using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Exceptions;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        int statusCode = GetStatusCode(exception);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        if (exception.GetType() == typeof(ValidationException))
        {
            return httpContext.Response.WriteAsync(new ExceptionModel()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage)
            }.ToString());
        }

        List<string> errors = new()
        {
            $"Error Message: {exception.Message}",
            $"Error Inner: {exception.InnerException?.ToString()}"
        };

        return httpContext.Response.WriteAsync(new ExceptionModel()
        {
            StatusCode = statusCode,
            Errors = errors
        }.ToString());
    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
