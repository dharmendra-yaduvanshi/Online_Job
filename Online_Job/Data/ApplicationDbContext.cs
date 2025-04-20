using Microsoft.EntityFrameworkCore;
using Online_Job.Models;

namespace Online_Job.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }  // Example DbSet for Jobs
    }
}
