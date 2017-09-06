using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExamManagementSystem.Models
{
    public class ExamManagementContext : IdentityDbContext<EMSUser>
    {
        public ExamManagementContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<EMSUser> EMSUser { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:ExamManagementContextConnection"];
            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }

    }
}