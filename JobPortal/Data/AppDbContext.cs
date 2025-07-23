using DevSpot.Models;
using JobPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace JobPortal.Data
{
    public class AppDbContext :IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            RelationalDatabaseCreator? dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreator != null)
            {
                if (!dbCreator.Exists())
                    dbCreator.Create();
                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                }
            }
        }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<JobApplicationModel> JobApplications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations can go here
        }
    }
}
