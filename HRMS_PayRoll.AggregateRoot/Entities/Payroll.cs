using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.AggregateRoot.Validations;

namespace HRMS_PayRoll.AggregateRoot.Entities
{
    public class Payroll
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("ID")]
        public int EmployeeID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Payment Date")]
        public DateOnly PaymentDate { get; set; }

        [Required]
        [Display(Name = "Gross Salary")]
        [Range(0, double.MaxValue, ErrorMessage = "Gross Salary must be a positive number")]
        public decimal GrossSalary { get; set; }

        [Required]
        [Display(Name = "Deduction Amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Deduction amount must be a positive number")]
        public decimal TaxDeduction { get; set; }


        [Display(Name = "Other Deductions")]
        [Range(0, double.MaxValue, ErrorMessage = "Other Deductions must be a positive number")]
        public decimal OtherDeductions { get; set; }

        [Required]
        [Display(Name = "Deduction Type")]
        [StringLength(50, ErrorMessage = "Deduction type cannot be longer than 50 characters")]
        public string DeductionType { get; set; }

        [Required]
        [Display(Name = "Net Salary")]
        public decimal NetSalary { get; set; }

        public virtual Employee? Employee { get; set; } // Navigation property

        public static bool Validation(PayrollDTO payrollDTO)
        {
            return ModelValidator.ValidatePayroll(payrollDTO);
        }
        public static Payroll ToEntity(PayrollDTO payrollDTO)
        {
            return new Payroll{
                EmployeeID= payrollDTO.EmployeeID,
                ID=payrollDTO.PayrollID,
                PaymentDate=payrollDTO.PayrollPaymentDate,
                GrossSalary=payrollDTO.PayrollGrossSalary,
                TaxDeduction=payrollDTO.PayrollTaxdeduction,
                OtherDeductions=payrollDTO.PayrollOtherDeduction,
                DeductionType=payrollDTO.PayrollOtherDeductionType,
                NetSalary=payrollDTO.PayrollNetSalary
            };
        }
        public static PayrollDTO ToDTO(Payroll payroll)
        {
            return new PayrollDTO {
                EmployeeID= payroll.EmployeeID,
                PayrollID=payroll.ID,
                PayrollGrossSalary=payroll.GrossSalary,
                PayrollTaxdeduction=payroll.TaxDeduction,
                PayrollOtherDeduction = payroll.OtherDeductions,
                PayrollOtherDeductionType=payroll.DeductionType,
                PayrollNetSalary=payroll.NetSalary,
                PayrollPaymentDate=payroll.PaymentDate
            };
        }
        public static EmployeePaymentDTO GetEmployeePaymentDTO(Payroll payroll)
        {
            var employeePayroll = new DTO.DTOs.EmployeePaymentDTO
            {
                EmployeeID = payroll.EmployeeID,
                EmployeeDateOfJoining = payroll.Employee.DateOfJoining,
                EmployeeName = payroll.Employee.Name,
                EmployeeMobileNumber = payroll.Employee.MobileNumber,
                EmployeeDeductionType = payroll.DeductionType,
                EmployeeDepartment = payroll.Employee.Department,
                EmployeeGrossSalary = payroll.GrossSalary,
                EmployeeNetSalary = payroll.NetSalary,
                EmployeeNID = payroll.Employee.NationalIDNumber,
                EmployeeOtherDeduction = payroll.OtherDeductions,
                EmployeePaymentDate = payroll.PaymentDate,
                EmployeeTaxDeduction = payroll.TaxDeduction
            };
            return employeePayroll;
        }
    }
}
