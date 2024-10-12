using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Handler.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> AllEmployee()
        {
            List<EmployeeDTO> list = await _employeeService.GetAllEmployee();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDTO employeeDTO)
        {
            int result = 0;
            result = await _employeeService.AddEmployee(employeeDTO);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(EmployeeDTO employeeDTO)
        {
            int result = await _employeeService.RemoveEmployee(employeeDTO);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> EditConfirmed(EmployeeDTO employeeDTO)
        {
            int result = 0;
            try
            {
                result = await _employeeService.UpdateEmployee(employeeDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_employeeService.EmployeeExist(employeeDTO.EmployeeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(result);
        }
    }
}
