using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Handler.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PyrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        private readonly IEmployeeService _employeeService;

        public PyrollController(IPayrollService payrollService, IEmployeeService employeeService)
        {
            _payrollService = payrollService;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PayrollDTO payrollDTO)
        {
            payrollDTO.PayrollTaxdeduction = payrollDTO.PayrollGrossSalary * 0.05m;

            payrollDTO.PayrollNetSalary = payrollDTO.PayrollGrossSalary - payrollDTO.PayrollTaxdeduction - payrollDTO.PayrollOtherDeduction;
            int result = await _payrollService.AddPayroll(payrollDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayroll()
        {
            List<PayrollDTO> payrollList = await _payrollService.GetPayrollList();
            return Ok(payrollList);
        }

    }
}
