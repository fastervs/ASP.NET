using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer
        : BaseEntity
    {
        //SqlLite doesnt support maxlength? [Column(TypeName = "text(200)")]
        
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [MaxLength(500)]
        public string Email { get; set; }

        public virtual ICollection<CustomerPreference> Preferences { get; set; }

        public virtual ICollection<CustomerPromoCode> PromoCode { get; set; }

        //TODO: Списки Preferences и Promocodes 
    }
}