using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.Handler.Services.Abstraction
{
    public interface IEmployeeService
    {
        public Task<int> AddEmployee(EmployeeDTO employeeDTO);
        public Task<int> RemoveEmployee(EmployeeDTO employeeDTO);
        public Task<List<EmployeeDTO>> GetAllEmployee();
        public Task<EmployeeDTO> GetEmployeeById(EmployeeDTO employeeDTO);
        public Task<int> UpdateEmployee(EmployeeDTO employeeDTO);
        public bool EmployeeExist(int id);
        public Task SaveChange();
    }
}
