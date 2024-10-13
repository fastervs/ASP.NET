using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class CreateOrEditCustomerRequest
    {
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public List<Guid> PreferenceIds { get; set; }

        public bool Validate()
        {
            if(string.IsNullOrEmpty(FirstName))
                return false;
            if (string.IsNullOrEmpty(LastName))
                return false;
            if (string.IsNullOrEmpty(Email))
                return false;
            return true;
        }
    }
}
