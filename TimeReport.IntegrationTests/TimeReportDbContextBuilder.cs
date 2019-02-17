using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TimeReport.Repository;
using Xunit;

namespace TimeReport.IntegrationTests
{
    public class TimeReportDbContextBuilder
    {
        public TimeReportContext Create()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
 
            var builder = new DbContextOptionsBuilder<TimeReportContext>();
 
            var connectionString = configuration.GetConnectionString("TimeReportConnectionString");
 
            builder.UseSqlServer(connectionString);
 
            return new TimeReportContext(builder.Options);
        }
    }
}
