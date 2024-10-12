using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.Repository.Repositories.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<int> Add(T entity);
        public Task<int> Update(T entity);
        public Task<int>  Delete(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetById(int id);
    }
}
