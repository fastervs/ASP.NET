using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.EntitiesRelations
{
    public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder
                .HasKey(bc => new { bc.EmployeeId, bc.RoleId });

            builder
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.Roles)
                .HasForeignKey(bc => bc.EmployeeId);
            builder
                .HasOne(bc => bc.Role)
                .WithMany()
                .HasForeignKey(bc => bc.RoleId);
        }
    }
}
