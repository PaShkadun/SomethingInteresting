using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Shops.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger logger;

        public ExceptionMiddleware(RequestDelegate request, ILogger logger)
        {
            this.request = request;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                logger.Information("Response to {address}", context.Request.Path);
                await request.Invoke(context);
            }
            catch (Exception exception)
            {
                await context.Response.WriteAsync("Something went wrong...\n");
                await context.Response.WriteAsync(exception.Message);

                var error = exception.Message + "\n" + exception?.InnerException?.Message;

                logger.Error(error);
                logger.Error("Error query: {query}", context.Request.Path);
            }

            if (context.Request.Path == "/index.html")
            {
                request?.Invoke(context);
            }
            else if (context.GetEndpoint() is null)
            {
                await context.Response.WriteAsync("This address isn't exists\n");

                logger.Error("Invalid path {path}", context.Request.Path);
            }
        }
    }
}
