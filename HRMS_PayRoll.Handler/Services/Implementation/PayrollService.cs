using HRMS_PayRoll.AggregateRoot.Entities;

using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Handler.Services.Abstraction;
using HRMS_PayRoll.Repository.Data;
using HRMS_PayRoll.Repository.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace HRMS_PayRoll.Handler.Services.Implementation
{
    public class PayrollService : IPayrollService
    {
        private readonly IGenericRepository<Payroll> _payrollRepository;
        private readonly ApplicationDbContext _context;

        public PayrollService(IGenericRepository<Payroll> payrollRepository, ApplicationDbContext context)
        {
            _payrollRepository = payrollRepository;
            _context = context;
        }

        public async Task<int> AddPayroll(PayrollDTO payrollDTO)
        {
            var payrollEntity = Payroll.ToEntity(payrollDTO);
            return await _payrollRepository.Add(payrollEntity);
        }

        public Task<List<Payroll>> GetPaymentHistory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeePaymentDTO> GetPayroll(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PayrollDTO>> GetPayrollList()
        {
            var payrollList=await _payrollRepository.GetAllAsync();
            var payrollDTOList=new List<PayrollDTO>();
            foreach (var payroll in payrollList)
            {
                payrollDTOList.Add(Payroll.ToDTO(payroll));
            }
            return payrollDTOList;
        }

        public Task<Payroll> GetPayrollById(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChange()
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Payroll>> GetPaymentHistory(int id)
        //{
        //    var payrollList = _context.payrolls.Where(p => p.EmployeeID == id).
        //        OrderByDescending(p => p.PaymentDate).ToList();
        //    return payrollList;
        //}

        //public async Task<DTO.DTOs.EmployeePaymentDTO> GetPayroll(int id)
        //{
        //    var payroll = await _context.payrolls.Include(p => p.Employee).
        //        FirstOrDefaultAsync(p => p.ID == id);
        //    var employeePayroll = Payroll.GetEmployeePaymentDTO(payroll);
        //    return await employeePayroll;
        //}

        //public async Task<Payroll> GetPayrollById(int id)
        //{
        //   return await _payrollRepository.GetById(id);
        //}
        //public async Task SaveChange()
        //{
        //    await _context.SaveChangesAsync();
        //}
    }
}
