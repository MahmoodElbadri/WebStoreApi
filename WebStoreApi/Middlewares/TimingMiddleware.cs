using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebStoreApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;

        public TimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            DateTime start = DateTime.Now;
            var result = _next(context);
            DateTime end = DateTime.Now;
            TimeSpan timeTaken = end - start;
            Console.WriteLine($"Time taken: {timeTaken.TotalMilliseconds} ms");
            return result;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TimingMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimingMiddleware>();
        }
    }
}
