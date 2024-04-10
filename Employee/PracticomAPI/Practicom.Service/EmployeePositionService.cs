using Practicom.Core.Entites;
using Practicom.Core.Repositories;
using Practicom.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Service
{
    public class EmployeePositionService:IEmployeePositionService
    {
        private readonly IEmployeePositionRepository _employeePositionRepository;
       public EmployeePositionService(IEmployeePositionRepository employeePositionRepository)
        {
            _employeePositionRepository = employeePositionRepository;
        }
        public async Task<IEnumerable<EmployeePosition>> GetPositionEmployee()
        {
           return await _employeePositionRepository.GetPositionEmployee();
        }
        public async Task<EmployeePosition> GetById(int id)
        {
            return  await _employeePositionRepository.GetById(id);
        }
        public  async Task<EmployeePosition> AddPositionEmployee(EmployeePosition employee)
        {
            return await _employeePositionRepository.AddPositionEmployee(employee); 
        }
        public async Task<EmployeePosition> UpdatePositionEmployee(int id, EmployeePosition employee)
        {
            return await _employeePositionRepository.UpdatePositionEmployee(id, employee);
        }

        public async Task DeletePositionEmployee(int employeeId)
        {
            await _employeePositionRepository.DeletePositionEmployee(employeeId);
        }

       

    

        
    }
}
