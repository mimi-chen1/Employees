using Practicom.Core.Entites;

namespace Practicom.API.Models
{
    public class EmployeePostModel
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public bool Status { get; set; }
        public IEnumerable<EmployeePositionPostModel> positions { get; set; }



    }
}
