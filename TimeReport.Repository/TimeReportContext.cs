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
    }
}
