using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController
        : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IRepository<Employee> employeeRepository, IRepository<Role> roleRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns>
        /// List of EmployeeShortResponse
        /// </returns>
        [HttpGet]
        public async Task<List<EmployeeShortResponse>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeesModelList = employees.Select(x =>
                new EmployeeShortResponse()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FullName = x.FullName,
                }).ToList();

            return employeesModelList;
        }

        /// <summary>
        /// Получить данные сотрудника по id
        /// </summary>
        /// <returns>
        /// EmployeeResponse or NotFound
        /// </returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            var employeeModel = new EmployeeResponse()
            {
                Id = employee.Id,
                Email = employee.Email,

                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };
            employeeModel.GetRoles(employee.Roles.ToList());
            return employeeModel;
        }


        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <returns>
        /// EmployeeShortResponse or BadRequest or InternalError
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeShortResponse>> CreateEmployeeAsync(CreateOrEditEmployeeRequest request)
        {
            var roles = await _roleRepository
                .GetRangeByIdsAsync(request.RoleIds);

            var employee = new Employee()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Id=Guid.NewGuid(),
            };
            employee.Roles = roles.Select(x => new EmployeeRole()
            {
                Employee = employee,
                Role = x
            }).ToList();

            

            var newEmployee = await _employeeRepository.AddAsync(employee);
            if (newEmployee != null)
                return _mapper.Map<EmployeeShortResponse>(newEmployee);

            return StatusCode(500);
        }
    }
}