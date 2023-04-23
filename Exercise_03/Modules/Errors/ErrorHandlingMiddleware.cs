using Newtonsoft.Json;
using System.Net;

namespace Exercise_03.Modules.Errors
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
 
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/json";

                var errorMessage = JsonConvert.SerializeObject(new
                {
                    title = "Internal Server Error",
                    status = 500
                });

                Console.WriteLine(exception);
                await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
            }
        }
    }
}
