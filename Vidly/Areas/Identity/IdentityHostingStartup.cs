using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vidly.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Vidly.Areas.Identity.IdentityHostingStartup))]
namespace Vidly.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VidlyIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("VidlyIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<VidlyIdentityDbContext>();
            });
        }
    }
}