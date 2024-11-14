using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class CreateOrEditEmployeeRequest
    {
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        public List<Guid> RoleIds { get; set; }
    }
}
