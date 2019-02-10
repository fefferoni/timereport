using System;
using System.Collections.Generic;
using System.Linq;
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

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Data.Entities.TimeReport> TimeReports { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Set default values
            foreach (var entityType in builder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property("DateCreated")
                            .HasDefaultValueSql("getutcdate()");

                        x.Property("DateModified")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }

            // Seed some data during development
            var now = DateTime.UtcNow;
            builder.Entity<Task>().HasData( 
                new Task
                {
                    Id = 1,
                    Name = "White-box testing",
                    Background = "Testing of a new feature in our system.",
                    StartDateTime = now.Date.AddDays(-1),
                    EndDateTime = now.Date.AddDays(1),
                    TimeType = TimeType.FixedPrice,
                    Goal = "Complete regression tests."
                },
                new Task
                {
                    Id = 2,
                    Name = "Lazy loading",
                    Background = "Dashboard needs lazy loading.",
                    StartDateTime = now.Date.AddDays(-7),
                    EndDateTime = now.Date.AddDays(14),
                    TimeType = TimeType.ByTheHour,
                    Goal = "Development complete."
                });
            builder.Entity<Data.Entities.TimeReport>().HasData(
                new
                {
                    Id = 1,
                    DateCreated = now,
                    DateModified = now,
                    Date = now.AddDays(-1),
                    TimeWorked = 5.0,
                    TaskId = 1
                },
                new
                {
                    Id = 2,
                    DateCreated = now,
                    DateModified = now,
                    Date = now.AddDays(-2),
                    TimeWorked = 2.0,
                    TaskId = 2
                },
                new
                {
                    Id = 3,
                    DateCreated = now,
                    DateModified = now,
                    Date = now.AddDays(-3),
                    TimeWorked = 1.5,
                    TaskId = 2
                });
        }
    }
}
