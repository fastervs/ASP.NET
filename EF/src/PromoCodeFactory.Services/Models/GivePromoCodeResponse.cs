using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Services.Models
{
    public class GivePromoCodeResponse
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public List<string> PromoCodes { get; set; }
    }
}
