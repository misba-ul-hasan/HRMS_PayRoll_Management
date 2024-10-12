using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Handler.Services.Abstraction;
using HRMS_PayRoll.Handler.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace HRMS_PayRoll.MVC.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IPayrollService _payrollService;
        private readonly IEmployeeService _employeeService;

        public PayrollController(IPayrollService payrollService, IEmployeeService employeeService)
        {
            _payrollService = payrollService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Create(int id)
        {
            var employeeDTO = await _employeeService.GetEmployeeById(id);
            //AggregateRoot.Entities.Employee employee = await _employeeService.GetEmployeeById(id);
            ViewData["Ëmployee"] = employeeDTO.EmployeeName;
            ViewData["EmployeeId"] = employeeDTO.EmployeeID;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Payroll payroll, string submitButton)
        {
            if (ModelState.IsValid)
            {
                payroll.TaxDeduction = payroll.GrossSalary * 0.05m;

                // Calculate Net Salary (Gross Salary - Tax Deduction - Other Deductions)
                payroll.NetSalary = payroll.GrossSalary - payroll.TaxDeduction - payroll.OtherDeductions;
                payroll.ID = 0;
                // Save Payroll record
                _payrollService.AddPayroll(payroll);
                await _payrollService.SaveChange();

                if (submitButton == "GeneratePaySlip")
                {
                    // Redirect to the PaySlip view
                    return RedirectToAction("PaySlip", new { id = payroll.ID });
                }
                else
                {
                    // Redirect to the Employee List view
                    return RedirectToAction("EmployeeView", "Employee");
                }
            }
            return View(payroll);
        }
        public async Task<IActionResult> PaySlip(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var payroll = await _payrollService.GetPayroll(id);
            if (payroll == null)
            {
                return NotFound();
            }

            return View(payroll);
        }
        public async Task<IActionResult> GeneratePaySlipPdf(int id)
        {
            var payroll = await _payrollService.GetPayroll(id);
            

            if (payroll == null)
            {
                return NotFound();
            }
            return new ViewAsPdf("PaySlip", payroll)
            {
                FileName = $"Payslip_{payroll.EmployeeName}_{payroll.EmployeePaymentDate:yyyyMMdd}.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--disable-smart-shrinking"
            };
        }
        public async Task<IActionResult> PaymentHistory(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            var payrollList = await _payrollService.GetPaymentHistory(id);
            ViewData["employeeName"] = employee.EmployeeName;
            ViewData["phoneNumber"] = employee.EmployeeMobileNumber;
            return View(payrollList);
        }
    }
}
