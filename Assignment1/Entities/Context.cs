using Microsoft.EntityFrameworkCore;

namespace Assignment.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<UserTechnologies> UserTechnologies { get; set; }




    }
}
