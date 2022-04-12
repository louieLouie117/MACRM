using Microsoft.EntityFrameworkCore;

namespace KcPilot.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<API> APIs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobComment> JobComments { get; set; }
        public DbSet<JobStatus> JobStatuss { get; set; }
        public DbSet<Market> Markets { get; set; }

        public DbSet<Role> Roles { get; set; }




    }
}