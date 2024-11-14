using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //TODO: Добавить список предпочтений
        public List<PromoCodeShortResponse> PromoCodes { get; set; }

        public List<PreferenceShortReponse> Preferences { get; set; }

        public void GetPreference(List<CustomerPreference> customerPreferences)
        {
            Preferences = new List<PreferenceShortReponse>();
            foreach (CustomerPreference customerPreference in customerPreferences)
            {
                Preferences.Add(new PreferenceShortReponse()
                {
                    Description = customerPreference.Preference.Name
                });
            }
        }

        public void GetPromoCodes(List<PromoCode> customerPromocodes)
        {
            if (customerPromocodes == null)
                return;
            PromoCodes = new List<PromoCodeShortResponse>();
            foreach (PromoCode customerPromocode in customerPromocodes)
            {
                PromoCodes.Add(new PromoCodeShortResponse()
                {
                    ServiceInfo = customerPromocode.ServiceInfo,
                    Code = customerPromocode.Code,
                    Id= customerPromocode.Id,

                });
            }
        }

        public CustomerResponse(Customer customer )
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            GetPreference(customer.Preferences.ToList());
            GetPromoCodes(customer.PromoCodes.ToList());
        }

        public CustomerResponse() { }
    }
}
