using Microsoft.EntityFrameworkCore;

namespace KcPilot.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ServiceJob> ServiceJobs { get; set; }
        public DbSet<Tech> Techs { get; set; }
        public DbSet<JobStatus> JobStatuss { get; set; }


    }
}