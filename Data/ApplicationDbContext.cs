using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RPM_Tool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Landlord",
                    NormalizedName = "LANDLORD"
                },
                new IdentityRole
                {
                    Name = "Tenant",
                    NormalizedName = "TENANT"
                }); 

        }
        // All tables need to be listed as DBSet here

        //public DbSet<RPM_Tool.Models.Name of Model> Name of Model { get; set; }
    }
}
