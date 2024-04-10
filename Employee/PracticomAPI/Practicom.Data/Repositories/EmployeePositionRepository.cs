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
    public class EmployeePositionRepository : IEmployeePositionRepository
    {
        private readonly EmployeeContex _employeeContex;
        public EmployeePositionRepository(EmployeeContex employeeContex)
        {
            _employeeContex = employeeContex;
        }
        public async Task<IEnumerable<EmployeePosition>> GetPositionEmployee()
        {
            return await _employeeContex.employeePositions.ToListAsync();

        }
        public async Task<EmployeePosition> GetById(int id)
        {
            var employee= await _employeeContex.employeePositions.Where(e => e.Id == id).FirstOrDefaultAsync();
            return employee;


        }
        public async Task<EmployeePosition> AddPositionEmployee(EmployeePosition employee)
        {
           _employeeContex.employeePositions.AddAsync(employee);
            await _employeeContex.SaveChangesAsync();
            return employee;
       
        }
        public async Task<EmployeePosition> UpdatePositionEmployee(int id, EmployeePosition employee)
        {
            var exsitPositionEmployee = await GetById(id);
             _employeeContex.Entry(exsitPositionEmployee).CurrentValues.SetValues(employee);
            await _employeeContex.SaveChangesAsync();
            return employee;
        }
        public async Task DeletePositionEmployee(int employeeId)
        {
            var PositionEmployee = await GetById(employeeId);
            _employeeContex.employeePositions.Remove(PositionEmployee);
            await _employeeContex.SaveChangesAsync();
        }

        
              

       
    }
}
