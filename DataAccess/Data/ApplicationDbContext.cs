

using DataAccess.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TaskRecord> TaskRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TaskRecord>().HasKey(c => c.Id);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<TaskRecord>().HasData(
                new TaskRecord { Id = 1, Title = "Task 1", Description = "Description 1", CreatedAt = DateTime.Now },
                new TaskRecord { Id = 2, Title = "Task 2", Description = "Description 2", CreatedAt = DateTime.Now.AddDays(-1),Status=Status.Completed },
                new TaskRecord { Id = 3, Title = "Task 3", Description = "Description 3", CreatedAt = DateTime.Now.AddDays(-2), Status = Status.Completed },
                new TaskRecord { Id = 4, Title = "Task 4", Description = "Description 4", CreatedAt = DateTime.Now.AddDays(-3) , Status = Status.Completed },
                new TaskRecord { Id = 5, Title = "Task 5", Description = "Description 5", CreatedAt = DateTime.Now.AddDays(-4) , Status = Status.Completed },
                new TaskRecord { Id = 6, Title = "Task 6", Description = "Description 6", CreatedAt = DateTime.Now.AddDays(-5) , Status = Status.Completed },
                new TaskRecord { Id = 7, Title = "Task 7", Description = "Description 7", CreatedAt = DateTime.Now.AddDays(-6) , Status = Status.Completed },
                new TaskRecord { Id = 8, Title = "Task 8", Description = "Description 8", CreatedAt = DateTime.Now.AddDays(-7) , Status = Status.Pending },
                new TaskRecord { Id = 9, Title = "Task 9", Description = "Description 9", CreatedAt = DateTime.Now.AddDays(-8) , Status = Status.Pending },
                new TaskRecord { Id = 10, Title = "Task 10", Description = "Description 10", CreatedAt = DateTime.Now.AddDays(-9) , Status = Status.Pending }
            );
        }
    }
}