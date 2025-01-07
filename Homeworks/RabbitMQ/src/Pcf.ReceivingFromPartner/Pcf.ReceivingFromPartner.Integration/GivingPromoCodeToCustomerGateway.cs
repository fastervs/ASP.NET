using System.Net.Http;
using System.Threading.Tasks;
using Pcf.ReceivingFromPartner.Integration.Dto;
using Pcf.ReceivingFromPartner.Core.Abstractions.Gateways;
using Pcf.ReceivingFromPartner.Core.Domain;
using MassTransit;
using MessageBusDtos;

namespace Pcf.ReceivingFromPartner.Integration
{
    public class GivingPromoCodeToCustomerGateway
        : IGivingPromoCodeToCustomerGateway
    {
        private readonly HttpClient _httpClient;

        private readonly IBus _bus;

        public GivingPromoCodeToCustomerGateway(HttpClient httpClient, IBus bus)
        {
            _httpClient = httpClient;
            _bus = bus;
        }

        public async Task GivePromoCodeToCustomer(PromoCode promoCode)
        {
            var dto = new GivePromoCodeToCustomerMessage()
            {
                PartnerId = promoCode.Partner.Id,
                BeginDate = promoCode.BeginDate.ToShortDateString(),
                EndDate = promoCode.EndDate.ToShortDateString(),
                PreferenceId = promoCode.PreferenceId,
                PromoCode = promoCode.Code,
                ServiceInfo = promoCode.ServiceInfo,
                PartnerManagerId = promoCode.PartnerManagerId
            };

            //var response = await _httpClient.PostAsJsonAsync("api/v1/promocodes", dto);

            //response.EnsureSuccessStatusCode();

            await _bus.Publish(dto);
        }
    }
}