using FutureProjects.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Infrastructure.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly FutureProjectsDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(FutureProjectsDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }
        public async Task<T> CreateAsync(T entity)
        {
            var res = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var res = await _dbSet.FirstOrDefaultAsync(expression);

            if (res == null)
            {
                return false;
            }

            _dbSet.Remove(res);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAnyAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var res = await _dbSet.FirstOrDefaultAsync(expression);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {

            var res = _dbSet.Update(entity);

            await _context.SaveChangesAsync();
            return res.Entity;

        }
    }
}