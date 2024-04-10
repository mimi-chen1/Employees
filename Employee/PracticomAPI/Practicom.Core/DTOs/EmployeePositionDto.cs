using Practicom.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core.DTOs
{
    public class EmployeePositionDto
    {
       public int PositionId { get; set; }
         public PositionDto position { get; set; }
       
        public bool IsAdministrative { get; set; }
        public DateTime DateStart { get; set; }
    }
}
