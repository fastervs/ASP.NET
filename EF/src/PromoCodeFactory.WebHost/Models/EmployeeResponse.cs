using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public List<RoleItemResponse> Role { get; set; }

        public int AppliedPromocodesCount { get; set; }

        public void GetRoles(List<EmployeeRole> roles)
        {
            Role = new List<RoleItemResponse>();
            foreach (EmployeeRole role in roles)
            {
                Role.Add(new RoleItemResponse()
                {
                    Description = role.Role.Description,
                    Name = role.Role.Name,
                });
            }
        }
    }
}