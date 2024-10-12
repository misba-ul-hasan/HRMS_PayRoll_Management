using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.DTO.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Joining is required")]
        public DateOnly EmployeeDateOfJoining { get; set; }
        public string EmployeeDepartment { get; set; }
        public decimal EmployeeSalary { get; set; }
        public string EmployeeNIDNumber { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public string EmployeeFathersName { get; set; }
        public string EmployeeMothersName { get; set; }
        public DateTime? EmployeeBirthDate { get; set; }
    }
}
