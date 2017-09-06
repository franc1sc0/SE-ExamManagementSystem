using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Identity.EntityFramework;
using ExamManagementSystem.Models;

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

        //public DbSet<Exam> Exams { get; set; }
        //public DbSet<RegExam> RegExam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:ExamManagementContextConnection"];
            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }

    }
}