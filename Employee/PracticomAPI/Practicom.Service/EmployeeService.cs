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
    public class EmployeeService:IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
           _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetEmployee()//get
        {
            return await _employeeRepository.GetEmployee();
        }
        public async Task<Employee> GetById(int id)//getbyid
        {
            return await _employeeRepository.GetById(id);
        }
        public async Task<Employee> AddEmployee(Employee employee)//post
        {
           return await _employeeRepository.AddEmployee(employee);

        }
        public async Task<Employee> UpdateEmployee( Employee employee) //put
        
        {
            return await _employeeRepository.UpdateEmployee( employee);
        }
        public async Task DeleteEmployee(int employeeId)
        {
           await _employeeRepository.DeleteEmployee(employeeId);
        }
             
    }
}
