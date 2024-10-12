using HRMS_PayRoll.AggregateRoot.Validations;
using HRMS_PayRoll.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.AggregateRoot.Entities
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Joining is required")]
        public DateOnly DateOfJoining { get; set; }

        [StringLength(50, ErrorMessage = "Department name cannot be longer than 50 characters")]
        public string Department { get; set; }

        [Display(Name = "Basic Salary")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "National ID Number is required")]
        [StringLength(20, ErrorMessage = "National ID Number cannot be longer than 20 characters")]
        public string NationalIDNumber { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [Phone(ErrorMessage = "Please enter a valid mobile number")]
        [StringLength(15, ErrorMessage = "Mobile Number cannot be longer than 15 characters")]
        public string MobileNumber { get; set; }

        [StringLength(100, ErrorMessage = "Father's Name cannot be longer than 100 characters")]
        public string FathersName { get; set; }

        [StringLength(100, ErrorMessage = "Mother's Name cannot be longer than 100 characters")]
        public string MothersName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public static bool Validation(EmployeeDTO employeeDTO)
        {
            return ModelValidator.ValidateEmployee(employeeDTO);
        }
        public static Employee ToEntity(EmployeeDTO employeeDTO)
        {
            return new Employee
            {
                ID = employeeDTO.EmployeeID,
                Name = employeeDTO.EmployeeName,
                DateOfJoining = employeeDTO.EmployeeDateOfJoining,
                Salary = employeeDTO.EmployeeSalary,
                DateOfBirth = employeeDTO.EmployeeBirthDate,
                FathersName = employeeDTO.EmployeeFathersName,
                MobileNumber = employeeDTO.EmployeeMobileNumber,
                MothersName = employeeDTO.EmployeeMothersName,
                NationalIDNumber = employeeDTO.EmployeeNIDNumber,
                Department = employeeDTO.EmployeeDepartment
            };
        }
        public static EmployeeDTO ToDTO(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeDepartment = employee.Department,
                EmployeeBirthDate = employee.DateOfBirth,
                EmployeeDateOfJoining = employee.DateOfJoining,
                EmployeeFathersName = employee.FathersName,
                EmployeeID=employee.ID,
                EmployeeName=employee.Name,
                EmployeeMobileNumber = employee.MobileNumber,
                EmployeeMothersName=employee.MothersName,
                EmployeeNIDNumber=employee.NationalIDNumber,
                EmployeeSalary=employee.Salary
            };
        }
    }
}
