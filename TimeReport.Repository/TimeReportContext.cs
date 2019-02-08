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
        public TimeReportContext(DbContextOptions<TimeReportContext> options) : base(options)
        {
            
        }

        //public DbSet<Task> Tasks { get; set; }
        //public DbSet<Data.Entities.TimeReport> TimeReports { get; set; }
        //public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var now = DateTime.UtcNow;

            builder.Entity<Task>().HasData(
                new
                {
                    Id = 1,
                    Name = "White-box testing",
                    Background = "Testing of a new feature in our system.",
                    DateCreated = now,
                    DateModified = now,
                    StartDateTime = DateTime.Today.AddDays(-1),
                    EndDateTime = DateTime.Today.AddDays(1),
                    TimeType = TimeType.FixedPrice,
                    Goal = "Complete regression tests."
                },
                new
                {
                    Id = 2,
                    Name = "Lazy loading",
                    Background = "Dashboard needs lazy loading.",
                    DateCreated = now,
                    DateModified = now,
                    StartDateTime = DateTime.Today.AddDays(-7),
                    EndDateTime = DateTime.Today.AddDays(14),
                    TimeType = TimeType.ByTheHour,
                    Goal = "Development complete."
                });
        }
    }
}
