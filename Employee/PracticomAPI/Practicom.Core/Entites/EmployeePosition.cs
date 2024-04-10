using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core.Entites
{
    public class EmployeePosition
    {
       public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PositionId { get; set; }
         public Position Position { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime DateStart { get; set; }
    }
}
