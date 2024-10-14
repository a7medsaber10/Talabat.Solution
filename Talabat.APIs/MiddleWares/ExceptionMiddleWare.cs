using System.Net;
using System.Text.Json;
using Talabat.APIs.Errors;

namespace Talabat.APIs.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                var statuscode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statuscode;

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var response = _env.IsDevelopment() ? 
                                                    new APIExceptionResponse(statuscode, ex.Message, ex.StackTrace.ToString()) 
                                                    :
                                                    new APIExceptionResponse(statuscode);

                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
