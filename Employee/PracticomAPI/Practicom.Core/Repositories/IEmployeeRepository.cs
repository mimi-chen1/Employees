using Practicom.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core.Repositories
{
    public interface IEmployeeRepository
    {

          Task<IEnumerable<Employee>> GetEmployee();


         Task<Employee> GetById(int id);

         Task<Employee> AddEmployee(Employee employee);//post

        Task<Employee> UpdateEmployee(Employee employee);//put


        Task DeleteEmployee(int employeeId);//delete
       

    }
}
