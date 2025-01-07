using MassTransit;
using MessageBusDtos;
using Pcf.Administration.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.Administration.Core.MessageHandlers
{
    public class PartnerPromocodeEventConsumer : IConsumer<NotificationToPartnerManagerMessage>
    {
        private readonly EmployeeService _employeeService;

        public PartnerPromocodeEventConsumer(EmployeeService employeeService) { 
            _employeeService = employeeService;
        }

        public async Task Consume(ConsumeContext<NotificationToPartnerManagerMessage> context)
        {
            
            var message = context.Message;

            // Perform some processing with the message
            await _employeeService.UpdateAppliedPromocodesAsync(message.PartnerManagerId);
            // Handle the message
        }
    }
}
