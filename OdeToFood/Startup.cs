using System;
using System.Threading.Tasks;
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
            GlobalConfiguration.Configuration
            .UseSqlServerStorage(
                "DefaultConnection",
                new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });


            app.UseHangfireDashboard();
            app.UseHangfireServer();

        }
    }
}
