using Microsoft.AspNetCore.Mvc;
using NicksSchoolDiary.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace NicksSchoolDiary.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                var details = new ProblemDetails
                {
                    Title = "Domain Exception",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(details);
            }
            catch (ArgumentException ex)
            {
                // Log the exception (you can use a logging library here)
                var genericMessage = "Bad Request";
                var statusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = genericMessage,
                    Status = statusCode,
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch (ValidationException ex)
            {
                var details = new ProblemDetails
                {
                    Title = "Domain Exception",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(details);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging library here)
                var genericMessage = "Internal Server Error";
                var statusCode = StatusCodes.Status500InternalServerError;

                var problemDetails = new ProblemDetails
                {
                    Title = genericMessage,
                    Status = statusCode,
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
