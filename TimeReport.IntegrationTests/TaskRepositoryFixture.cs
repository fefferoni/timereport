using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeReport.Data.Entities;
using TimeReport.Repository;
using Xunit;

namespace TimeReport.IntegrationTests
{
    public class TaskRepositoryFixture
    {
        private TaskRepository systemUnderTest;

        public TaskRepository SystemUnderTest
        {
            get
            {
                if (systemUnderTest == null)
                {
                    var context = new TimeReportDbContextBuilder().Create();

                    context.Database.EnsureCreated();

                    systemUnderTest = new TaskRepository(context);
                }

                return systemUnderTest;
            }
        }

        public TaskRepositoryFixture()
        {
            systemUnderTest = null;
        }

        private static Task Task => new Task
        {
            Name = "TaskRepository Test task",
            Background = "Test background",
            Goal = "Test goal",
            TimeType = TimeType.FixedPrice,
            StartDateTime = DateTime.Today,
            EndDateTime = DateTime.Today.AddDays(3)
        };

        [Fact]
        [Trait("Category","Integration.Sql")]
        public void TaskRepository_InsertTask()
        {
            var actual = Task;

            SystemUnderTest.Insert(actual);

            Assert.True(actual.Id != 0, "Task id should not be 0.");
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        public void TaskRepository_InsertTaskWithTimeReports()
        {
            var actual = Task;

            var timeReport1 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today,
                TimeWorked = 7.5
            };

            var timeReport2 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today.AddDays(-1),
                TimeWorked = 1
            };

            actual.TimeReports.Add(timeReport1);
            actual.TimeReports.Add(timeReport2);

            SystemUnderTest.Insert(actual);

            Assert.True(actual.Id != 0, "Task id should not be 0.");
            Assert.True(actual.TimeReports.ElementAt(0).Id != 0, "Task timeReport #0 id should not be 0.");
            Assert.True(actual.TimeReports.ElementAt(1).Id != 0, "Task timeReport #1 id should not be 0.");
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        public void TaskRepository_InsertTaskWithTimeReports_UpdateTaskAndTimeReports()
        {
            var expected = Task;

            var timeReport1 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today,
                TimeWorked = 7.5
            };

            var timeReport2 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today.AddDays(-1),
                TimeWorked = 1
            };

            expected.TimeReports.Add(timeReport1);
            expected.TimeReports.Add(timeReport2);

            SystemUnderTest.Insert(expected);

            expected.Name = "modified";
            timeReport1.TimeWorked = 3;
            timeReport2.TimeWorked = 3;

            SystemUnderTest.Update(expected);

            systemUnderTest = null;

            var actual = SystemUnderTest.Get(expected.Id);

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(2, actual.TimeReports.Count);
            Assert.All(actual.TimeReports, report => Assert.Equal(3, report.TimeWorked));
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        public void TaskRepository_InsertTask_DeleteTask()
        {
            var expected = Task;

            SystemUnderTest.Insert(expected);

            Assert.True(expected.Id != 0, "Task id should not be 0.");

            SystemUnderTest.Delete(expected);

            systemUnderTest = null;

            var actual = SystemUnderTest.Get(expected.Id);

            Assert.Null(actual);
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        public void TaskRepository_InsertTaskWithTimeReport_DeleteTimeReport()
        {
            // Arrange
            var expected = Task;
            
            var timeReport1 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today,
                TimeWorked = 7.5
            };
            var timeReport2 = new Data.Entities.TimeReport
            {
                Date = DateTime.Today,
                TimeWorked = 6
            };
            
            expected.TimeReports.Add(timeReport1);
            expected.TimeReports.Add(timeReport2);

            SystemUnderTest.Insert(expected);

            Assert.True(expected.Id != 0, "Task id should not be 0.");

            // Act
            expected.TimeReports.Remove(timeReport1);
            SystemUnderTest.Update(expected);

            systemUnderTest = null;

            // Assert
            var actual = SystemUnderTest.Get(expected.Id);

            Assert.Equal(1, actual.TimeReports.Count);
        }

        [Fact]
        [Trait("Category","Integration.Sql")]
        public void TaskRepository_InsertTask_UpdateTaskDetachedInstance()
        {
            // Arrange
            var expected = Task;

            SystemUnderTest.Insert(expected);
            systemUnderTest = null;
            expected.Name = "very modified task name";

            // Act
            SystemUnderTest.Update(expected);

            // Assert
            systemUnderTest = null;
            var actual = SystemUnderTest.Get(expected.Id);
            Assert.Equal(expected.Name, actual.Name);
        }
    }
}
