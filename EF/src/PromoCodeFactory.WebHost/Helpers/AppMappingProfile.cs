using AutoMapper;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Services.Models;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Helpers
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile()
        {
            CreateMap<GivePromoCodeRequest, GivePromoCodeDto>();
            CreateMap<PromoCode, PromoCodeShortResponse>();
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Customer, CustomerShortResponse>();
            //CreateMap<Preference, PreferenceShortReponse>();
            CreateMap<CustomerPreference, PreferenceShortReponse>();
            CreateMap<Employee, EmployeeShortResponse>();
        }
    }
}
