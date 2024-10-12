using HRMS_PayRoll.AggregateRoot.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Payroll> payrolls { get; set; }
        public DbSet<User> users { get; set; }
    }
}
