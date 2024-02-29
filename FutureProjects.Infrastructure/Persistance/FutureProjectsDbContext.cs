using DOT.DOMEN.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Infrastructure.Persistance
{
    public class FutureProjectsDbContext : DbContext
    {
        public FutureProjectsDbContext(DbContextOptions<FutureProjectsDbContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User>  Users{get;set;}   
    }
}
