using Practicom.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core.Services
{
    public interface IEmployeePositionService
    {
        Task<IEnumerable<EmployeePosition>> GetPositionEmployee();


        Task<EmployeePosition> GetById(int id);

        Task<EmployeePosition> AddPositionEmployee(EmployeePosition employee);//post

        Task<EmployeePosition> UpdatePositionEmployee(int id, EmployeePosition employee);//put


        Task DeletePositionEmployee(int employeeId);//delete
    }
}
