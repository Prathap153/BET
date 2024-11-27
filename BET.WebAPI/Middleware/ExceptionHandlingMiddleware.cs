using BET.WebAPI.Response;
using System.Net;
using System.Text.Json;

namespace BET.WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                ApplicationException _ => context.Response.StatusCode = (int)HttpStatusCode.BadRequest,
                KeyNotFoundException _ => context.Response.StatusCode = (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException _ => context.Response.StatusCode = (int)HttpStatusCode.Unauthorized,
                _ => context.Response.StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var response = new Response<string>(exception.Message);
            var result = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(result);
        }
    }
}
