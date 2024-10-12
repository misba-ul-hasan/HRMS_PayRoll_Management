using HRMS_PayRoll.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.AggregateRoot.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public User ToEntity(UserDTO userDTO)
        {
            this.Id= userDTO.Id;
            this.UserName= userDTO.UserName;
            this.Password= userDTO.Password;
            this.Email= userDTO.Email;
            this.PhoneNumber= userDTO.PhoneNumber;
            return this;
        }
    }
}
