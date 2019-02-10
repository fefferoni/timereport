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

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Data.Entities.TimeReport> TimeReports { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
