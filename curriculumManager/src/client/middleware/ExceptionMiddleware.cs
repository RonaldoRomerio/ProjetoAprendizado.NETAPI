using curriculumManager.src.domain.models;
using System.Net;
using System.Text.Json;

namespace curriculumManager.src.client.middleware
{
    public class exceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Exception> _logger;
        private readonly IHostEnvironment _environment;

        public exceptionMiddleware(RequestDelegate next, ILogger<Exception> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = _environment.IsDevelopment() ? 
                    new Error(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace.ToString()) :
                    new Error(context.Response.StatusCode.ToString(), ex.Message, "internal server error");
                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, option); 
                await context.Response.WriteAsync(json);
            }
        }
    }
}
