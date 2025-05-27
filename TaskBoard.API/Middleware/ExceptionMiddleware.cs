using System.Net;
using TaskBoard.Application.Models;

namespace TaskBoard.API.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        private readonly RequestDelegate _next = next;
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, _logger);
            }
        }
        private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception,
        ILogger<ExceptionMiddleware> logger
    )
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            APIResponse details = new()
            {
                IsSuccess = false,
                Message = exception.Message
            };

            logger.LogError(exception, "Error: {details.Message}", details.Message);

            await context.Response.WriteAsJsonAsync(details);
        }
    }
}
