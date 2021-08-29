using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRP.Data;
using WebApplicationRP.Models;
using WebApplicationRP.Services;

namespace WebApplicationRP
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<WebApplicationRPContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("WebApplicationRPContextConnection"));
			});

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddRoles<IdentityRole>().AddEntityFrameworkStores<WebApplicationRPContext>();

			services.AddTransient<IDBOperations<Student>, StudentDB>();
			services.AddTransient<IDBOperations<Department>, DepartmentDB>();
			services.AddRazorPages();
		}
		public string GetConfiguration(string configKey)
		{
			//try
			//{
				string connectionString = Configuration.GetConnectionString(configKey);
				if(connectionString != null) return connectionString;
			//}
			//catch (Exception ex)
			//{
				//throw (ex);
			//}
			return "";
		}
		

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
