using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Services;
using PromoCodeFactory.Services.Models;
using PromoCodeFactory.WebHost.Models;
using YamlDotNet.Core;



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

        private readonly IMapper _mapper;


        public PromocodesController(IRepository<PromoCode> promocodesRepository,PromoCodeCustomerService promocodeCustomerService,
            IMapper mapper)
        {
            _promocodeRepository = promocodesRepository;
            _promoCodeCustomerService = promocodeCustomerService;
            _mapper = mapper;
            
        }

        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns>
        /// List of PromoCodeShortResponse
        /// </returns>
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
        /// <returns>
        /// Ok if success, else bad request 
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {

            var res=await _promoCodeCustomerService.
                GivePromoCodesToCustomersWithPreferenceAsync(_mapper.Map<GivePromoCodeDto>(request));
            if(!res)
                return BadRequest("No customers with given preference");

            return Ok();
        }
    }
}