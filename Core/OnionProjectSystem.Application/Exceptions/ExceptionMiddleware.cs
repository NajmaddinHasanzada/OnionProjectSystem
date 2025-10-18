using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;


namespace OnionProjectSystem.Application.Exceptions
{
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
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Errors = ((ValidationException)exception).Errors.Select(e => e.ErrorMessage)
                }.ToString());
            }

            List<string> errors  = new()
            {
                $"Error message: {exception.Message}",
            };

            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                StatusCode = statusCode,
                Errors = errors
            }.ToString());
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };


    }
}
