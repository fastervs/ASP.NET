﻿using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Employee
        : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }

        public virtual ICollection<EmployeeRole> Roles { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}