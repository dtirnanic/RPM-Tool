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
            builder.Entity<Building_Utility>()
                .HasKey(bu => new { bu.BuildingId, bu.UtilityId });
            builder.Entity<Building_Utility>()
                .HasOne(bu => bu.Building)
                .WithMany(b => b.Building_Utilities)
                .HasForeignKey(bu => bu.BuildingId);
            builder.Entity<Building_Utility>()
                .HasOne(bu => bu.Utility)
                .WithMany(u => u.Building_Utilities)
                .HasForeignKey(bu => bu.UtilityId);

            builder.Entity<Building_Vendor>()
                .HasKey(bu => new { bu.BuildingId, bu.VendorId });
            builder.Entity<Building_Vendor>()
                .HasOne(bu => bu.Building)
                .WithMany(b => b.Building_Vendors)
                .HasForeignKey(bu => bu.BuildingId);
            builder.Entity<Building_Vendor>()
                .HasOne(bu => bu.Vendor)
                .WithMany(u => u.Building_Vendors)
                .HasForeignKey(bu => bu.VendorId);

            builder.Entity<Building_ScheduledMaintenance>()
             .HasKey(bu => new { bu.BuildingId, bu.ScheduledMaintenanceId });
            builder.Entity<Building_ScheduledMaintenance>()
                .HasOne(bu => bu.Building)
                .WithMany(b => b.ScheduledMaintenance_Buildings)
                .HasForeignKey(bu => bu.BuildingId);
            builder.Entity<Building_ScheduledMaintenance>()
                .HasOne(bu => bu.ScheduledMaintenance)
                .WithMany(u => u.ScheduledMaintenance_Buildings)
                .HasForeignKey(bu => bu.ScheduledMaintenanceId);

        }
        // All tables need to be listed as DBSet here

        public DbSet<RPM_Tool.Models.Building> Buildings { get; set; }
        public DbSet<RPM_Tool.Models.Landlord> Landlords { get; set; }
        public DbSet<RPM_Tool.Models.MortgageAndEscrow> MortgageAndEscrows  { get; set; }
        public DbSet<RPM_Tool.Models.ScheduledMaintenance> ScheduledMaintenances { get; set; }
        public DbSet<RPM_Tool.Models.Tenant> Tenants { get; set; }
        public DbSet<RPM_Tool.Models.TenantMaintenanceRequest> TenantMaintenanceRequests  { get; set; }
        public DbSet<RPM_Tool.Models.Unit> Units  { get; set; }
        public DbSet<RPM_Tool.Models.Utility> Utilities { get; set; }
        public DbSet<RPM_Tool.Models.Vendor> Vendors { get; set; }

    }
}
