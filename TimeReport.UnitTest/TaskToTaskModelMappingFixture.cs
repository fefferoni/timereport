using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Background, actual.Background);
            Assert.Equal(expected.Customer.Id, actual.CustomerId);
            Assert.Equal(expected.Customer.Name, actual.CustomerName);
            Assert.Equal(expected.Goal, actual.Goal);
            Assert.Equal(expected.TimeType, actual.TimeType);
            Assert.Equal(expected.Project.Id, actual.ProjectId);
            Assert.Equal(expected.Project.Name, actual.ProjectName);
            Assert.Equal(expected.StartDateTime, actual.StartDateTime);
            Assert.Equal(expected.EndDateTime, actual.EndDateTime);
            Assert.Equal(expected.DateCreated, actual.DateCreated);
            Assert.Equal(expected.DateModified, actual.DateModified);
            Assert.Equal(expected.Id, actual.Id);
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
            Assert.Equal(expected.TimeReports, actual.TimeReports);
            // Todo: skapa delad utility metod som assertar TimeReports. Skapa även fixture för mappning av timereport->TimereportModel.
        }

        [Fact]
        [Trait("Category","UnitTest.Mapping")]
        public void MapTaskModelToTask()
        {
            
        }
    }
}
