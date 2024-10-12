using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Handler.Services.Abstraction;
using HRMS_PayRoll.Handler.Services.Implementation;
using HRMS_PayRoll.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HRMS_PayRoll.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task <IActionResult> EmployeeView()
        {
            List<EmployeeDTO> list = await _employeeService.GetAllEmployee();
            return View(list);
        }
        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeDTO employeeDTO)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = await _employeeService.AddEmployee(employeeDTO);
                return RedirectToAction("EmployeeView","Employee");
            }
            return View(employeeDTO);
        }
        public async Task<IActionResult> Details(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null) return NotFound();
            employeeDTO = await _employeeService.GetEmployeeById(employeeDTO);
            if (employeeDTO == null)
            {
                return NotFound();
            }
            return View(employeeDTO);
        }
        public async Task<IActionResult> Edit(EmployeeDTO employeeDTO)
        {
            employeeDTO = await _employeeService.GetEmployeeById(employeeDTO);
            return View(employeeDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(EmployeeDTO employeeDTO)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
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
                return RedirectToAction("EmployeeView");
            }
            return View(employeeDTO);
        }

        public async Task<IActionResult> Delete(EmployeeDTO employeeDTO)
        {
            employeeDTO = await _employeeService.GetEmployeeById(employeeDTO);
            if (employeeDTO == null)
            {
                return NotFound();
            }

            return View(employeeDTO);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(EmployeeDTO employeeDTO)
        {
            employeeDTO = await _employeeService.GetEmployeeById(employeeDTO);
            int result = await _employeeService.RemoveEmployee(employeeDTO);
            return RedirectToAction("EmployeeView");
        }
    }
}
