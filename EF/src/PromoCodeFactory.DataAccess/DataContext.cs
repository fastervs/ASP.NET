using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<PromoCode> PromoCodes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Preference> Preferences { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }



        public DataContext() {
            
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<EmployeeRole>()
                .HasKey(bc => new { bc.RoleId, bc.EmployeeId });

            modelBuilder.Entity<Employee>()
            .HasMany(e => e.Role)
            .WithMany(e => e.Employees)
            .UsingEntity<EmployeeRole>();
            */

            modelBuilder.Entity<PromoCodePreference>()
                .HasKey(bc => new { bc.PromoCodeId, bc.PreferenceId });

            modelBuilder.Entity<CustomerPromoCode>()
                .HasKey(bc => new { bc.PromoCodeId, bc.CustomerId });

            modelBuilder.Entity<CustomerPreference>()
                .HasKey(bc => new { bc.CustomerId, bc.PreferenceId });
            /*
            modelBuilder.Entity<CustomerPromoCode>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.PromoCode)
                .HasForeignKey(bc => bc.CustomerId);
            modelBuilder.Entity<CustomerPromoCode>()
                .HasOne(bc => bc.PromoCode)
                .WithMany()
                .HasForeignKey(bc => bc.PromoCodeId);

            

            
            modelBuilder.Entity<Customer>()
            .HasMany(c => c.Preferences)
            .WithOne() // Assuming one preference belongs to one customer
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.PromoCode)
                .WithOne() // Assuming one promo code belongs to one customer
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<CustomerPreference>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.Preferences)
                .HasForeignKey(bc => bc.CustomerId);
            modelBuilder.Entity<CustomerPreference>()
                .HasOne(bc => bc.Preference)
                .WithMany()
                .HasForeignKey(bc => bc.PreferenceId);*/

            /*
            modelBuilder.Entity<Customer>().
                HasMany(x=>x.PromoCode)
                .WithOne(c=>c.Customer)
                .OnDelete(DeleteBehavior.Cascade);*/

            /*
            modelBuilder.Entity<Employee>()
            .HasMany(e => e.Role)
            .WithMany(s => s.Employees)
            .UsingEntity<EmployeeRole>();*/

            modelBuilder.Entity<EmployeeRole>()
                .HasKey(bc => new { bc.EmployeeId, bc.RoleId });
            
            /*
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.Roles)
                .HasForeignKey(bc => bc.EmployeeId);
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(bc => bc.Role)
                .WithMany()
                .HasForeignKey(bc => bc.RoleId);*/

        }
    }
}
