using System.Linq;
using AutoFixture;
using AutoMapper;
using TimeReport.Data.Entities;
using TimeReport.Web.Api.Models;
using TimeReport.Web.Api.Models.Mapping;
using Xunit;

namespace TimeReport.UnitTests
{
    public class TaskToTaskModelMappingFixture
    {
        private IMapper systemUnderTest;
        private Fixture fixture;

        public IMapper SystemUnderTest
        {
            get
            {
                if (systemUnderTest == null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile(new MappingProfile());
                    });
                    systemUnderTest = config.CreateMapper();
                }

                return systemUnderTest;
            }
        }

        public Fixture Fixture
        {
            get
            {
                if (fixture == null)
                {
                    fixture = new Fixture();
                    fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                        .ForEach(b => fixture.Behaviors.Remove(b));
                    fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                }
                return fixture;
            }
        }

        [Fact]
        [Trait("Category","UnitTest.Mapping")]
        public void MapTaskToTaskModel_Simple()
        {
            // Arrange
            var expected = Fixture.Create<Task>();
            expected.TimeReports.Clear();

            // Act
            var actual = SystemUnderTest.Map<TaskModel>(expected);
            
            // Assert
            AssertEqual(expected, actual);
            Assert.Empty(actual.TimeReports);
        }

        [Fact]
        [Trait("Category","UnitTest.Mapping")]
        public void MapTaskToTaskModel_WithTimeReports()
        {
            // Arrange
            var expected = Fixture.Create<Task>();

            // Act
            var actual = SystemUnderTest.Map<TaskModel>(expected);

            // Assert
            Assert.NotEmpty(expected.TimeReports);
            var i = 0;
            foreach (var timeReport in expected.TimeReports)
            {
                AssertEqual(timeReport, actual.TimeReports.ElementAt(i++));
            }
        }

        [Fact]
        [Trait("Category","UnitTest.Mapping")]
        public void MapTaskToTaskModel_Reverse()
        {
            // Arrange
            var expected = Fixture.Create<TaskModel>();

            // Act
            var actual = SystemUnderTest.Map<Task>(expected);

            // Assert
            AssertEqual(actual, expected);
            var i = 0;
            foreach (var timeReport in expected.TimeReports)
            {
                AssertEqual(actual.TimeReports.ElementAt(i++), timeReport);
            }
        }

        private void AssertEqual(Task task, TaskModel taskModel)
        {
            Assert.Equal(task.Name, taskModel.Name);
            Assert.Equal(task.Background, taskModel.Background);
            Assert.Equal(task.Customer.Id, taskModel.CustomerId);
            Assert.Equal(task.Customer.Name, taskModel.CustomerName);
            Assert.Equal(task.Goal, taskModel.Goal);
            Assert.Equal(task.TimeType, taskModel.TimeType);
            Assert.Equal(task.Project.Id, taskModel.ProjectId);
            Assert.Equal(task.Project.Name, taskModel.ProjectName);
            Assert.Equal(task.StartDateTime, taskModel.StartDateTime);
            Assert.Equal(task.EndDateTime, taskModel.EndDateTime);
            Assert.Equal(task.DateCreated, taskModel.DateCreated);
            Assert.Equal(task.DateModified, taskModel.DateModified);
            Assert.Equal(task.Id, taskModel.Id);
            Assert.Equal(task.TimeReports.Count, taskModel.TimeReports.Count);
        }

        private void AssertEqual(Data.Entities.TimeReport report, TimeReportModel reportModel)
        {
            Assert.Equal(report.Date, reportModel.Date);
            Assert.Equal(report.TimeWorked, reportModel.TimeWorkedInHours);
            Assert.Equal(report.Id, reportModel.Id);
            Assert.Equal(report.DateCreated, reportModel.DateCreated);
            Assert.Equal(report.DateModified, reportModel.DateModified);
        }

    }
}
