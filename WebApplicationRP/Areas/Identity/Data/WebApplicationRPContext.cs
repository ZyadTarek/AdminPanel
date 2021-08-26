using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationRP.Models;

namespace WebApplicationRP.Data
{
    public class WebApplicationRPContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public WebApplicationRPContext(DbContextOptions<WebApplicationRPContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<Student>().HasData(
            //    new Department {Id = 1, Name = "DotNet"},
            //    new Department {Id = 2, Name = "BI" },
            //    new Department {Id = 3, Name = "AI" }
            //    );
        }
    }
}
