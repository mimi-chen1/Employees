using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core.Entites
{
    public enum Gender { male = 1, female = 2 }
   
    public class Employee
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "First name can be at most 50 characters long")]

        public string FirstName {  get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Last name can be at most 50 characters long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ID number is required")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "ID number must be 9 digits long")]
        public string Tz { get; set; }
        [Required(ErrorMessage = "Employment start date is required")]

        public DateTime EmploymentStartDate {  get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth {  get; set; }
        [Required(ErrorMessage = "Gender is required")]

        public Gender Gender {  get; set; }
        [Required(ErrorMessage = "Status is required")]

        public bool Status { get; set; }
        public IEnumerable<EmployeePosition>positions {  get; set; }

    }
}
