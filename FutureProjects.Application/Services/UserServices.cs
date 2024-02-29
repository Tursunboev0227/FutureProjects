using DOT.DOMEN.Entities.DTOS;
using DOT.DOMEN.Entities.Models;
using FutureProjects.Application.Abstractions.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Application.Services
{
    public class UserServices : IUserService
    {
        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByAnyAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
