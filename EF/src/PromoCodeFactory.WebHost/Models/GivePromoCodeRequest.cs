using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class GivePromoCodeRequest
    {
        [Required]
        [StringLength(150)]
        public string ServiceInfo { get; set; }
        [Required]
        [StringLength(250)]
        public string PartnerName { get; set; }
        [Required]
        [StringLength(250)]
        public string PromoCode { get; set; }
        [Required]
        [StringLength(150)]
        public string Preference { get; set; }
    }
}
