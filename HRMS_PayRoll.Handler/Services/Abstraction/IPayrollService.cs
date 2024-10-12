using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.Handler.Services.Abstraction
{
    public interface IPayrollService
    {
        public Task<int> AddPayroll(PayrollDTO payrollDTO);
        public Task<Payroll> GetPayrollById(int id);
        public Task<DTO.DTOs.EmployeePaymentDTO> GetPayroll(int id);
        public Task<List<Payroll>> GetPaymentHistory(int id);
        public Task<List<PayrollDTO>> GetPayrollList();
        public Task SaveChange();

    }
}
