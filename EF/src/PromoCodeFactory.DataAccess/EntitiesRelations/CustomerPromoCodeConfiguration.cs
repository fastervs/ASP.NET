using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.EntitiesRelations
{
    public class CustomerPromoCodeConfiguration : IEntityTypeConfiguration<CustomerPromoCode>
    {
        public void Configure(EntityTypeBuilder<CustomerPromoCode> builder)
        {
            builder.HasKey(bc => new { bc.PromoCodeId, bc.CustomerId });
            /*
            builder
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.PromoCode)
                .HasForeignKey(bc => bc.CustomerId);


            builder
                .HasOne(bc => bc.PromoCode)
                .WithMany()
                .HasForeignKey(bc => bc.PromoCodeId);*/
        }
    }
}
