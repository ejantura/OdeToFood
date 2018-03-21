using System;
using System.Threading.Tasks;
using System.Web;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OdeToFood.Startup))]

namespace OdeToFood
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            var options = new DashboardOptions { AppPath = VirtualPathUtility.ToAbsolute("/Comments/Index") };

            app.UseHangfireDashboard("/HangfireJobs", options);
            app.UseHangfireServer();

        }
    }
}
