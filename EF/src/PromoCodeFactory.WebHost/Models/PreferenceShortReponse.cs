using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class PreferenceShortReponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public PreferenceShortReponse() { }

        public PreferenceShortReponse(Preference preference)
        {
            Id = preference.Id;
            Name = preference.Name;
        }
    }
}
