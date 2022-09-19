using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;

namespace RazorPages.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public LogRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, PersonsDbContext db)
        {
            var ip = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var url = httpContext.Request.GetDisplayUrl();
            var user_agent = httpContext.Request.Headers["User-Agent"].First();

            db.LogRequests.Add(new Data.Model.LogRequest()
            {
                Date = DateTime.Now,
                Ip = ip,
                Url = url,
                UserAgent = user_agent
            });
            db.SaveChanges();

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogRequestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogRequestMiddleware>();
        }
    }
}
