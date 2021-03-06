using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareSample
{
    public class Startup
    {
        public Startup(ILoggerFactory loggerFactory) 
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddConsole();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<VersionHeaderMiddleware>();
            app.UseMiddleware<SuperstitiousMiddleware>();
            app.Run(async ctx => 
            {
                ctx.Response.StatusCode = 200;
                await ctx.Response.WriteAsync("Hello world!");
            });
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}