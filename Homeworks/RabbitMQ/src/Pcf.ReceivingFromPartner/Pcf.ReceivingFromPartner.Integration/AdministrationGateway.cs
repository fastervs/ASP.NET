using System;
using System.Net.Http;
using System.Threading.Tasks;
using MassTransit;
using MessageBusDtos;
using Pcf.ReceivingFromPartner.Core.Abstractions.Gateways;

namespace Pcf.ReceivingFromPartner.Integration
{
    public class AdministrationGateway
        : IAdministrationGateway
    {
        private readonly HttpClient _httpClient;

        private readonly IBus _bus;

        public AdministrationGateway(HttpClient httpClient,IBus bus)
        {
            _httpClient = httpClient;
            _bus = bus;
        }

        public async Task NotifyAdminAboutPartnerManagerPromoCode(Guid partnerManagerId)
        {
            //var response = await _httpClient.PostAsync($"api/v1/employees/{partnerManagerId}/appliedPromocodes",
            //new StringContent(string.Empty));

            //response.EnsureSuccessStatusCode();
            var dto=new NotificationToPartnerManagerMessage() { PartnerManagerId=partnerManagerId};

            await _bus.Publish(dto);
        }
    }
}