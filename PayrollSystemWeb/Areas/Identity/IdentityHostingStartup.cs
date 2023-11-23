using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayrollWeb.Areas.Identity.Data;
using PayrollWeb.Data;

[assembly: HostingStartup(typeof(PayrollWeb.Areas.Identity.IdentityHostingStartup))]
namespace PayrollWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PayrollWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PayrollWebContextConnection")));

                services.AddDefaultIdentity<PayrollWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PayrollWebContext>();
            });
        }
    }
}