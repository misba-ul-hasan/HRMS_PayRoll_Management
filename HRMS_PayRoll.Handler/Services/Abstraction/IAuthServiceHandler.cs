using HRMS_PayRoll.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.Handler.Services.Abstraction
{
    public interface IAuthServiceHandler
    {
        public Task<int> AddUser(UserDTO userDTO);
        public string LogIn(LogInDTO logInDTO);
    }
}
