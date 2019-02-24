using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data.Entities;
using TimeReport.Repository;
using Xunit;
using Xunit.Sdk;

namespace TimeReport.IntegrationTests
{
    public class TimeReportDbContextEfCoreFixture
    {
        private TimeReportContext systemUnderTest;

        public TimeReportDbContextEfCoreFixture()
        {
            systemUnderTest = null;
        }

        public TimeReportContext SystemUnderTest
        {

            get
            {
                if (systemUnderTest == null)
                {
                    systemUnderTest = new TimeReportDbContextBuilder().Create();

                    systemUnderTest.Database.EnsureCreated();
                }

                return systemUnderTest;
            }
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        private void Ef_SaveTask_Simple()
        {
            var task = Task;

            SystemUnderTest.Tasks.Add(task);
            SystemUnderTest.SaveChanges();
            
            Assert.True(task.Id != 0, "Task id should not be 0.");
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        private void Ef_SaveTaskWithTimeReport_SingleTimeReport()
        {
            var task = Task;
            
            var timeReport = new Data.Entities.TimeReport
            {
                Date = DateTime.Today,
                TimeWorked = 1.5
            };

            task.TimeReports.Add(timeReport);

            SystemUnderTest.Tasks.Add(task);
            SystemUnderTest.SaveChanges();
            
            Assert.True(task.Id != 0, "Task id should not be 0.");
            Assert.True(task.TimeReports.Single().Id != 0, "Task timeReport id should not be 0.");
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        private void Ef_SaveTaskWithTimeReport_MultipleTimeReports()
        {
            var task = Task;
            
            var timeReport1 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today,
                TimeWorked = 1.5
            };

            var timeReport2 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today.AddDays(-1),
                TimeWorked = 4
            };

            task.TimeReports.Add(timeReport1);
            task.TimeReports.Add(timeReport2);

            SystemUnderTest.Tasks.Add(task);
            SystemUnderTest.SaveChanges();
            
            Assert.True(task.Id != 0, "Task id should not be 0.");
            Assert.True(task.TimeReports.ElementAt(0).Id != 0, "Task timeReport #0 id should not be 0.");
            Assert.True(task.TimeReports.ElementAt(1).Id != 0, "Task timeReport #1 id should not be 0.");
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        private void Ef_LoadTaskWithTimeReports_UsingFreshDbContext()
        {
            var expectedTask = Task;
            
            var timeReport1 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today,
                TimeWorked = 5.5
            };

            var timeReport2 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today.AddDays(-1),
                TimeWorked = 0.5
            };

            expectedTask.TimeReports.Add(timeReport1);
            expectedTask.TimeReports.Add(timeReport2);

            SystemUnderTest.Tasks.Add(expectedTask);
            SystemUnderTest.SaveChanges();

            // Create fresh db context
            systemUnderTest = null;

            var actualTask = SystemUnderTest.Tasks.Include(t => t.TimeReports).FirstOrDefault(t => t.Id == expectedTask.Id);

            Assert.NotNull(actualTask);
            Assert.NotNull(actualTask.TimeReports);
            Assert.NotEmpty(actualTask.TimeReports);
            Assert.Equal(2, actualTask.TimeReports.Count);
            Assert.All(actualTask.TimeReports, Assert.NotNull);
        }

        private static Task Task => new Task
        {
            Name = "Test task",
            Background = "Test background",
            Goal = "Test goal",
            TimeType = TimeType.ByTheHour,
            StartDateTime = DateTime.Today,
            EndDateTime = DateTime.Today.AddDays(3)
        };
    }
}
