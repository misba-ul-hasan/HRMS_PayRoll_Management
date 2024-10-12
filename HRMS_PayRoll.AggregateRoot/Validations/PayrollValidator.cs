using FluentValidation;
using HRMS_PayRoll.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.AggregateRoot.Validations
{
    internal class PayrollValidator : AbstractValidator<PayrollDTO>
    {
        public PayrollValidator()
        {
            // Validate PayrollID
            RuleFor(dto => dto.PayrollID)
                .GreaterThan(0).WithMessage("Payroll ID must be greater than zero.");

            // Validate PayrollPaymentDate
            RuleFor(dto => dto.PayrollPaymentDate)
                .NotEmpty().WithMessage("Payment Date is required.")
                .Must(BeAValidDate).WithMessage("Payment Date must be a valid date.");

            // Validate PayrollGrossSalary
            RuleFor(dto => dto.PayrollGrossSalary)
                .GreaterThan(0).WithMessage("Gross Salary must be greater than zero.");

            // Validate PayrollTaxdeduction
            RuleFor(dto => dto.PayrollTaxdeduction)
                .GreaterThanOrEqualTo(0).WithMessage("Tax Deduction must be a non-negative number.");

            // Validate PayrollOtherDeduction
            RuleFor(dto => dto.PayrollOtherDeduction)
                .GreaterThanOrEqualTo(0).WithMessage("Other Deduction must be a non-negative number.");

            // Validate PayrollOtherDeductionType
            RuleFor(dto => dto.PayrollOtherDeductionType)
                .NotEmpty().WithMessage("Deduction Type is required.")
                .MaximumLength(50).WithMessage("Deduction Type cannot be longer than 50 characters.");

            // Validate PayrollNetSalary
            RuleFor(dto => dto.PayrollNetSalary)
                .GreaterThan(0).WithMessage("Net Salary must be greater than zero.");
        }

        private bool BeAValidDate(DateOnly date)
        {
            return date != default;
        }
    }
}
