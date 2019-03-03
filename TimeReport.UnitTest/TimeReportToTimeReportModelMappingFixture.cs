using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFixture;
using AutoMapper;
using TimeReport.Web.Api.Models;
using TimeReport.Web.Api.Models.Mapping;
using Xunit;

namespace TimeReport.UnitTests
{
    public class TimeReportToTimeReportModelMappingFixture
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
        [Trait("Category", "UnitTest.Mapping")]
        public void MapTimeReportToTimeReportModel()
        {
            // Arrange
            var expected = Fixture.Create<Data.Entities.TimeReport>();

            // Act
            var actual = SystemUnderTest.Map<TimeReportModel>(expected);
            
            // Assert
            AssertEqual(expected, actual);
        }

        private void AssertEqual(Data.Entities.TimeReport report, TimeReportModel reportModel)
        {
            Assert.Equal(report.Id, reportModel.Id);
            Assert.Equal(report.TimeWorked, reportModel.TimeWorkedInHours);
            Assert.Equal(report.Date, reportModel.Date);
            Assert.Equal(report.DateCreated, reportModel.DateCreated);
            Assert.Equal(report.DateModified, reportModel.DateModified);
        }

        [Fact]
        [Trait("Category", "UnitTest.Mapping")]
        public void MapTimeReportToTimeReportModel_Reverse()
        {
            // Arrange
            var expected = Fixture.Create<TimeReportModel>();

            // Act
            var actual = SystemUnderTest.Map<Data.Entities.TimeReport>(expected);
            
            // Assert
            AssertEqual(actual, expected);
        }
    }
}
