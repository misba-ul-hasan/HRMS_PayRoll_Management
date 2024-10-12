using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.AggregateRoot.Validations;
using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Handler.Services.Abstraction;
using HRMS_PayRoll.Repository.Data;
using HRMS_PayRoll.Repository.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HRMS_PayRoll.Handler.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeService(IGenericRepository<Employee> employeeRepository, ApplicationDbContext applicationDbContext)
        {
            _employeeRepository = employeeRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
            var emoloyeeList= await _employeeRepository.GetAllAsync();
            var emoloyeeDTOList = new List<EmployeeDTO>();
            foreach (var employee in emoloyeeList)
            {
                emoloyeeDTOList.Add(Employee.ToDTO(employee));
            }
            return emoloyeeDTOList;
        }

        public async Task<EmployeeDTO> GetEmployeeById(EmployeeDTO employeeDTO)
        {
            var employeeEntity=Employee.ToEntity(employeeDTO);
            var employee = await _employeeRepository.GetById(employeeEntity.ID);
            return Employee.ToDTO(employee);
        }

        public async Task<int> RemoveEmployee(EmployeeDTO employeeDTO)
        {
            var employeeEntity= Employee.ToEntity(employeeDTO);
            int result= await _employeeRepository.Delete(employeeEntity);
            return result;
        }
        public async Task<int> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            int result = 0;
            if(Employee.Validation(employeeDTO))
            {
                var employeeEntity = Employee.ToEntity(employeeDTO);
                result = await _employeeRepository.Update(employeeEntity);
            }
            return result;
        }
        public async Task SaveChange()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public bool EmployeeExist(int id)
        {
            return _applicationDbContext.employees.Any(e => e.ID == id);
        }

        public async Task<int> AddEmployee(EmployeeDTO employeeDTO)
        {
            int result=0;
            if(Employee.Validation(employeeDTO))
            {
                Employee employeeEntity = Employee.ToEntity(employeeDTO);
               return result=await _employeeRepository.Add(employeeEntity);
            }
            return result;
        }
    }
}
