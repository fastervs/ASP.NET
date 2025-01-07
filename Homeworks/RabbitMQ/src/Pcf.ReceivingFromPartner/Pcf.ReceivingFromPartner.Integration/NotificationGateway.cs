using System;
using System.Threading.Tasks;
using MassTransit;
using MessageBusDtos;
using Pcf.ReceivingFromPartner.Core.Abstractions.Gateways;

namespace Pcf.ReceivingFromPartner.Integration
{
    public class NotificationGateway
        : INotificationGateway
    {
        private readonly IBus _bus;
        public NotificationGateway(IBus bus) {
            _bus = bus;
        }

        public async Task SendNotificationToPartnerAsync(Guid partnerId, string message)
        {
            //Код, который вызывает сервис отправки уведомлений партнеру
            var dto = new NotificationToPartnerMessage()
            {
                PartnerId = partnerId,
                Message = message
            };

            await _bus.Publish(dto);
        }
    }
}