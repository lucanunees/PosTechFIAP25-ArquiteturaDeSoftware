using Serilog;

namespace FiapCloudGames
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            Console.WriteLine("Iniciando a aplicação");
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                var username = httpContext.Request.Query.FirstOrDefault().Value;

                // Loga a requisição recebida
                Log.Information("Requisição recebida: {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);

                //valida se o nome do usuario é Admin.
                if (username.Count() > 0)
                {
                    if (username.Equals("admin"))
                    {
                        // Chama o próximo middleware na pipeline
                        await _next(httpContext);
                        return;
                    }

                    httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await httpContext.Response.WriteAsync("Usuário não autorizado.");

                }

                // Loga a resposta enviada
                Log.Information("Resposta enviada: {StatusCode}", httpContext.Response.StatusCode);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Registrar o erro com o Serilog
            Log.Error(exception, "An unhandled exception occurred.");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred. Please try again later."
            });
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
