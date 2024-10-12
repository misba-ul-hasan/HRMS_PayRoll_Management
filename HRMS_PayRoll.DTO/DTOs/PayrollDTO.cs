using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.DTO.DTOs
{
    public class PayrollDTO
    {
        public int EmployeeID { get; set; }
        public int PayrollID { get; set; }
        public DateOnly PayrollPaymentDate { get; set; }
        public decimal PayrollGrossSalary { get; set; }
        public decimal PayrollTaxdeduction { get; set; }
        public decimal PayrollOtherDeduction { get; set; }
        public string PayrollOtherDeductionType { get; set; }
        public decimal PayrollNetSalary { get; set; }
    }
}
