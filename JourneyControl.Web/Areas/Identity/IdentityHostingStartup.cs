using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(JourneyControl.Web.Areas.Identity.IdentityHostingStartup))]
namespace JourneyControl.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}