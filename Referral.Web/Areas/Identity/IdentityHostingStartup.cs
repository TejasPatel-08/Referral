using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Referral.Web.Areas.Identity.IdentityHostingStartup))]
namespace Referral.Web.Areas.Identity
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