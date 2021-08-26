using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationRP.Data;

[assembly: HostingStartup(typeof(WebApplicationRP.Areas.Identity.IdentityHostingStartup))]
namespace WebApplicationRP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApplicationRPContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApplicationRPContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebApplicationRPContext>();
            });
        }
    }
}