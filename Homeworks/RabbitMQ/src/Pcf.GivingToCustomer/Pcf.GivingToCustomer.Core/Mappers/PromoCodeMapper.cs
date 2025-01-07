﻿using MessageBusDtos;
using Pcf.GivingToCustomer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.Mappers
{
    public class PromoCodeMapper
    {
        public static PromoCode MapFromModel(GivePromoCodeToCustomerMessage request, Preference preference, IEnumerable<Customer> customers)
        {

            var promocode = new PromoCode();
            promocode.Id = request.PromoCodeId;

            promocode.PartnerId = request.PartnerId;
            promocode.Code = request.PromoCode;
            promocode.ServiceInfo = request.ServiceInfo;

            promocode.BeginDate = DateTime.Parse(request.BeginDate);
            promocode.EndDate = DateTime.Parse(request.EndDate);

            promocode.Preference = preference;
            promocode.PreferenceId = preference.Id;

            promocode.Customers = new List<PromoCodeCustomer>();

            foreach (var item in customers)
            {
                promocode.Customers.Add(new PromoCodeCustomer()
                {

                    CustomerId = item.Id,
                    Customer = item,
                    PromoCodeId = promocode.Id,
                    PromoCode = promocode
                });
            };

            return promocode;
        }
    }
}
