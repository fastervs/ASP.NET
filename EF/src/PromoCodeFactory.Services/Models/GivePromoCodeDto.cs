using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Services.Models
{
    public class GivePromoCodeDto
    {
        
        public string ServiceInfo { get; set; }
        
        public string PartnerName { get; set; }
        
        public string PromoCode { get; set; }
        
        public string Preference { get; set; }
    }
}
