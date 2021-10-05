using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StayOver.Areas.Identity.Data;
using StayOver.Data;

[assembly: HostingStartup(typeof(StayOver.Areas.Identity.IdentityHostingStartup))]
namespace StayOver.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDefaultIdentity<ApplicationUser>(options => 
                options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<StayOverDbContext>();
                services.AddControllersWithViews();
            });
        }
    }
}