

using Microsoft.Owin;
using Hangfire;
using Owin;

[assembly: OwinStartup(typeof(DotNetHangfire.Startup))]
namespace DotNetHangfire
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}