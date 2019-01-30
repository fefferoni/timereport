using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public class TimeReportContext : IdentityDbContext<User>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public TimeReportContext(DbContextOptions<TimeReportContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Task>().HasData( 
                new Task
                {
                    Id = 1,
                    Name = "White-box testing",
                    Background = "Testing of a new feature in our system.",
                    DateCreated = DateTime.UtcNow,
                    StartDateTime = DateTime.Today.AddDays(-1),
                    EndDateTime = DateTime.Today.AddDays(1),
                    TimeType = TimeType.FixedPrice,
                    Goal = "Complete regression tests."
                },
                new Task
                {
                    Id = 2,
                    Name = "Lazy loading",
                    Background = "Dashboard needs lazy loading.",
                    DateCreated = DateTime.UtcNow,
                    StartDateTime = DateTime.Today.AddDays(-7),
                    EndDateTime = DateTime.Today.AddDays(14),
                    TimeType = TimeType.ByTheHour,
                    Goal = "Development complete."
                });
        }
    }
}
