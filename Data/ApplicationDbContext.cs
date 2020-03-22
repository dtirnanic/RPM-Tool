using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RPM_Tool.Models;

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

        public DbSet<RPM_Tool.Models.Building> Buildings { get; set; }
        public DbSet<RPM_Tool.Models.Building_Utility> Building_Utilities { get; set; }
        public DbSet<RPM_Tool.Models.Building_Vendor> Building_Vendors { get; set; }
        public DbSet<RPM_Tool.Models.Landlord> Landlords { get; set; }
        public DbSet<RPM_Tool.Models.MortgageAndEscrow> MortgageAndEscrows { get; set; }
        public DbSet<RPM_Tool.Models.ScheduledMaintenance> ScheduledMaintenances { get; set; }
        public DbSet<RPM_Tool.Models.ScheduledMaintenance_Building> ScheduledMaintenance_Buildings { get; set; }
        public DbSet<RPM_Tool.Models.Tenant> Tenants { get; set; }
        public DbSet<RPM_Tool.Models.TenantMaintenanceRequest> TenantMaintenanceRequests { get; set; }
        public DbSet<RPM_Tool.Models.Unit> Units { get; set; }
        public DbSet<RPM_Tool.Models.Utility> Utilities { get; set; }
        public DbSet<RPM_Tool.Models.Vendor> Vendors { get; set; }

        public DbSet<TwilioAccount> TwilioAccounts {get;set;}


    }
}
