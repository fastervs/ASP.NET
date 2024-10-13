using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Services;

namespace PromoCodeFactory.WebHost.Controllers
{

    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController
        : ControllerBase
    {
        private readonly IRepository<PromoCode> _promocodeRepository;

        private readonly PromoCodeCustomerService _promoCodeCustomerService;
        

        public PromocodesController(IRepository<PromoCode> promocodesRepository,PromoCodeCustomerService promocodeCustomerService)
        {
            _promocodeRepository = promocodesRepository;
            _promoCodeCustomerService = promocodeCustomerService;
            
        }

        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
        {
            var promocodes = await _promocodeRepository.GetAllAsync();
            List<PromoCodeShortResponse> result = promocodes.Select(x=>new PromoCodeShortResponse()
            {
                Id = x.Id,
                PartnerName = x.PartnerName,
                Code = x.Code,
                ServiceInfo = x.ServiceInfo,
                BeginDate=x.BeginDate.ToShortDateString(),
                EndDate=x.EndDate.ToShortDateString(),
                PreferenceShortReponse=new PreferenceShortReponse(x.Preference)

            }).ToList();

            return result;
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            var res=await _promoCodeCustomerService.GivePromoCodesToCustomersWithPreferenceAsync(request);
            if(!res)
                return BadRequest("No customers with given preference");

            return Ok();
        }
    }
}