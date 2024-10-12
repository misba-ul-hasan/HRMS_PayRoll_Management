using FluentValidation;
using HRMS_PayRoll.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.AggregateRoot.Validations
{
    public static class ModelValidator
    {
        public static bool ValidateEmployee(EmployeeDTO employeeDTO)
        {
            EmployeeValidator employeeValidator = new EmployeeValidator();
            var result = employeeValidator.Validate(employeeDTO);
            return result.IsValid;
        }
        public static bool ValidatePayroll(PayrollDTO payrollDTO) {
            PayrollValidator payrollValidator = new PayrollValidator();
            var result = payrollValidator.Validate(payrollDTO);
            return result.IsValid;
        }
    }
}
