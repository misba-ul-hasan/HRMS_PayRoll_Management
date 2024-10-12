using HRMS_PayRoll.AggregateRoot.Entities;
using HRMS_PayRoll.DTO.DTOs;
using HRMS_PayRoll.Handler.Services.Abstraction;
using HRMS_PayRoll.Repository.Data;
using HRMS_PayRoll.Repository.Repositories.Abstraction;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.Handler.Services.Implementation
{
    public class AuthServiceHandler : IAuthServiceHandler
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly IGenericRepository<User> _employeeRepository;
        public AuthServiceHandler(ApplicationDbContext applicationDbContext,IConfiguration configuration,
            IGenericRepository<User> genericRepository)
        {
            _context = applicationDbContext;
            this.configuration = configuration;
            _employeeRepository = genericRepository;
        }

        public async Task<int> AddUser(UserDTO userDTO)
        {
            User userEntity=new User().ToEntity(userDTO);
            int result= await _employeeRepository.Add(userEntity);
            return result;
        }

        public string LogIn(LogInDTO logInDTO)
        {
            throw new NotImplementedException();
        }
    }
}
