using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindRazorPages.Models;

namespace NorthwindRazorPages.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext (DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<EmployeeTerritory>().ToTable("EmployeeTerritories");
            modelBuilder.Entity<Territory>().ToTable("Territories");
            modelBuilder.Entity<Region>().ToTable("Regions");

            modelBuilder.Entity<EmployeeTerritory>()
                .HasKey(c => new { c.EmployeeId, c.TerritoryId});
        }
    }
}
