using Microsoft.EntityFrameworkCore;
using Practicom.Core.Entites;
using Practicom.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Data.Repositories
{
    public class EmpolyeeRepository:IEmployeeRepository
    {
        private readonly EmployeeContex _employeeContex;
        public EmpolyeeRepository(EmployeeContex employeeContex)
        {
            _employeeContex = employeeContex;
        }
        public async Task<IEnumerable<Employee>> GetEmployee()//get
        {
            return await _employeeContex.employees.Include(e=>e.positions).ThenInclude(p=>p.Position).ToListAsync();
        }
        public async Task<Employee> GetById(int id)
        {
            return await _employeeContex.employees.Include(e=>e.positions).ThenInclude(p=>p.Position).FirstOrDefaultAsync(e=>e.Id==id);
        }
       
        public async Task<Employee> AddEmployee(Employee employee)//post
        {

            _employeeContex.employees.AddAsync(employee);
            await _employeeContex.SaveChangesAsync();
            return employee;


        }
       
        public async Task<Employee> UpdateEmployee(Employee employee)//put
        {
            var exsitEmployee = await GetById(employee.Id);
            _employeeContex.Entry(exsitEmployee).CurrentValues.SetValues(employee);
           await  _employeeContex.SaveChangesAsync();
            return employee;
        }
        public async Task DeleteEmployee(int employeeId)//delete
        {
            var employee = await GetById(employeeId);
            if(employee != null)
            {
                employee.Status = false;
            }
           
            await _employeeContex.SaveChangesAsync();

        }
    

}
}
