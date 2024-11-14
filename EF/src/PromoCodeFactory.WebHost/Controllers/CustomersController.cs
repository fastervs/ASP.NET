using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController
        : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Preference> _prefernceRepository;
        private readonly DataContext dataContext;

        private readonly IMapper _mapper;

        public CustomersController(IRepository<Customer> customerRepository, IRepository<Preference> preferenceRepository,
            DataContext context, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _prefernceRepository = preferenceRepository;
            dataContext=context;
            _mapper=mapper;
        }

        /// <summary>
        /// Получить всех клиентов
        /// </summary>
        /// <returns>
        /// List of CustomerShortResponse
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<CustomerShortResponse>>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();

            var customerModelList = customers.Select(x =>
                new CustomerShortResponse()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList();

            return customerModelList;
            
        }

        /// <summary>
        /// Получить информацию по одному клиенту
        /// </summary>
        /// <returns>
        /// CustomerResponse or NotFound
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            //var customerModel = new CustomerResponse(customer);
            var customerModel = _mapper.Map<CustomerResponse>(customer);
            

            return customerModel;
        }

        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <returns>
        /// Customer if success or BadRequest 
        /// InternalError Если не удалось добавить клиента но запрос валидацию прошёл
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CustomerShortResponse>> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            if (!request.Validate())
                return BadRequest();
            var preferences = await _prefernceRepository
                .GetRangeByIdsAsync(request.PreferenceIds);

            var customer = new Customer()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            if(preferences.Count()!=0)
                customer.Preferences = preferences.Select(x => new CustomerPreference()
                {
                    Customer = customer,
                    Preference = x
                }).ToList();

            var newCustomer=await _customerRepository.AddAsync(customer);
            if(newCustomer != null)
                return _mapper.Map<CustomerShortResponse>(newCustomer);

            return StatusCode(500);
            
        }


        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <returns>
        /// true or false if statuscode 200
        /// BadRequest or NotFound
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> EditCustomersAsync(Guid id,CreateOrEditCustomerRequest request)
        {
            if (!request.Validate())
                return BadRequest();
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            var preferences = await _prefernceRepository.GetRangeByIdsAsync(request.PreferenceIds);

            customer.Email = request.Email;
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Preferences.Clear();
            customer.Preferences = preferences.Select(x => new CustomerPreference()
            {
                Customer = customer,
                Preference = x
            }).ToList();

            

            return await _customerRepository.UpdateAsync(customer);
        }

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <returns>
        /// true, false or notfound
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCustomer(Guid id)
        {
            //TODO: Удаление клиента вместе с выданными ему промокодами
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return await _customerRepository.DeleteAsync(customer);
        }
    }
}