using DOT.DOMEN.Entities.DTOS;
using DOT.DOMEN.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<User> CreateAsync(User entity);
        public Task<User> GetByAnyAsync(Expression<Func<User, bool>> expression);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        public Task<User> UpdateAsync(int id,UserDTO user);
    }
}
