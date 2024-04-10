using Practicom.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core.DTOs
{
    public class EmployeeDto
    {
       public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public bool Status {  get; set; }    
        public IEnumerable<EmployeePositionDto> positions { get; set; }
       
       
    }
}
