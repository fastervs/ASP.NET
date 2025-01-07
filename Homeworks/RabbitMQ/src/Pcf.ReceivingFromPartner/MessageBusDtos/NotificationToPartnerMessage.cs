using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBusDtos
{
    public class NotificationToPartnerMessage
    {
        public Guid PartnerId { get; set; }

        public string Message { get; set; }
    }
}
