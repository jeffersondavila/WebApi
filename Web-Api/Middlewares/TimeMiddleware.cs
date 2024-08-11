using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Web_Api.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class TimeMiddleware
	{
		private readonly RequestDelegate _next;

		public TimeMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			await _next(httpContext);

			if(httpContext.Request.Query.Any(p=> p.Key == "time"))
			{
				await httpContext.Response.WriteAsync(DateTime.Now.ToShortTimeString());
			}
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class TimeMiddlewareExtensions
	{
		public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<TimeMiddleware>();
		}
	}
}
