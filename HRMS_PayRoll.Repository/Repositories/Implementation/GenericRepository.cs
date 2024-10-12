using HRMS_PayRoll.Repository.Data;
using HRMS_PayRoll.Repository.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_PayRoll.Repository.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<int> Add(T entity)
        {
           _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(T entity)
        {
            int result = 0;
            if (entity != null)
            {
                _dbSet.Remove(entity);
                result= await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> Update(T entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
