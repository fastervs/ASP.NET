using Pcf.Administration.Core.Abstractions.Repositories;
using Pcf.Administration.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.Administration.Core.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> UpdateAppliedPromocodesAsync(Guid id)
        {
            
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return false;

            employee.AppliedPromocodesCount++;

            await _employeeRepository.UpdateAsync(employee);

            return true;
        }
    }
}
