﻿
using System.Linq;
using System.Threading.Tasks;
using System;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Services.Models;

namespace PromoCodeFactory.Services
{
    public class PromoCodeCustomerService
    {
        private readonly IRepository<PromoCode> _promocodeRepository;
        private readonly IRepository<Preference> _prefernceRepository;

        private readonly IRepository<Customer> _customerRepository;

        public PromoCodeCustomerService(IRepository<PromoCode> promocodesRepository, IRepository<Preference> preferenceRepository,
            IRepository<Customer> customerRepository)
        {
            _promocodeRepository = promocodesRepository;
            _prefernceRepository = preferenceRepository;
            _customerRepository = customerRepository;
        }

        public async Task<bool> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeDto request)
        {
            var preferences = await _prefernceRepository.Search(x => x.Name == request.Preference);

            var preference = preferences.FirstOrDefault();
            if (preference == null)
            {
                return false;
            }

            Guid prefId = preference.Id;
            var customers = await _customerRepository.Search(x => x.Preferences.Any(z => z.PreferenceId == prefId));
            if (customers.Count() == 0)
                return false;

            foreach (var customer in customers)
            {
                var newpromocode = new PromoCode()
                {
                    BeginDate = DateTime.Now,
                    PartnerName = request.PartnerName,
                    ServiceInfo = request.ServiceInfo,
                    Id = Guid.NewGuid(),
                    Code = request.PromoCode
                };

                newpromocode.PreferenceId = preference.Id;
                newpromocode.CustomerId = customer.Id;
                customer.PromoCodes.Add(newpromocode);
                await _promocodeRepository.AddAsync(newpromocode);
            }

            return true;
        }
    }
}