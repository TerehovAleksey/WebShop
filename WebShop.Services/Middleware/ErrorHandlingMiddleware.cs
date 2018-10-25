using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebShop.Services.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ErrorHandlingMiddleware));

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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                throw;
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            Log.Error(ex.Message, ex);
            return Task.CompletedTask;
        }
    }
}
