using MassTransit;
using MessageBusDtos;
using Pcf.GivingToCustomer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.MessageHandlers
{
    public class NewPromocodeMessageHandler : IConsumer<GivePromoCodeToCustomerMessage>
    {
        private readonly PromoCodesService _promocodesService;

        public NewPromocodeMessageHandler(PromoCodesService promoCodesService)
        {
            _promocodesService = promoCodesService;
        }

        public async Task Consume(ConsumeContext<GivePromoCodeToCustomerMessage> context)
        {
            // Extract the message from the context
            var message = context.Message;

            // Perform some processing with the message
            await _promocodesService.GivePromoCodesToCustomersWithPreferenceAsync(message);
            // Handle the message
        }
    }
}
