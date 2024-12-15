﻿using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer
        : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<CustomerPreference> Preferences { get; set; }

        public virtual ICollection<PromoCode> PromoCodes { get; set; }

    }
}