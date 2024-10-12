using FluentValidation;
using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.AggregateRoot.Validations
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator() {
            RuleFor(emp => emp.EmployeeName)
            .NotEmpty().WithMessage("Employee Name is required")
            .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters");

            // Validate DateOfJoining
            RuleFor(emp => emp.EmployeeDateOfJoining)
                .NotEmpty().WithMessage("Date of Joining is required");

            // Validate Department
            RuleFor(emp => emp.EmployeeDepartment)
                .MaximumLength(50).WithMessage("Department name cannot be longer than 50 characters");
        }
    }
}
