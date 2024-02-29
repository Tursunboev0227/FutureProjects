using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Application.Abstractions
{
    
        public interface IBaseRepository<T> where T : class
        {
            public Task<T> CreateAsync(T entity);
            public Task<T> GetByAnyAsync(Expression<Func<T, bool>> expression);
            public Task<IEnumerable<T>> GetAllAsync();
            public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
            public Task<T> UpdateAsync(T entity);
        
    }
}
