using DOT.DOMEN.Entities.Models;
using FutureProjects.Application.Abstractions;
using FutureProjects.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Infrastructure.BaseRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FutureProjectsDbContext context) :base(context, context.Set<User>()) 
        {
        }
    }
}
