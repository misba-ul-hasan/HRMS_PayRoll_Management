using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.DTO.DTOs
{
    public class EmployeePaymentDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDepartment { get; set; }
        public DateOnly EmployeeDateOfJoining { get; set; }
        public string EmployeeNID { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public DateOnly EmployeePaymentDate {  get; set; }
        public Decimal EmployeeGrossSalary { get; set; }
        public Decimal EmployeeTaxDeduction { get; set; }
        public Decimal EmployeeOtherDeduction { get; set; }
        public string EmployeeDeductionType { get; set; }
        public Decimal EmployeeNetSalary { get; set; }

    }
}
