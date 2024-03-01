using DOT.DOMEN.Entities.Models;
using Microsoft.EntityFrameworkCore;


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
