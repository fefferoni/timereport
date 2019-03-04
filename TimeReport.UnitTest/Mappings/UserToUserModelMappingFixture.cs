using System.Linq;
using AutoFixture;
using AutoMapper;
using TimeReport.Data.Entities;
using TimeReport.Web.Api.Models;
using TimeReport.Web.Api.Models.Mapping;
using Xunit;

namespace TimeReport.UnitTests.Mappings
{
    public class UserToUserModelMappingFixture
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
        public void MapUserToUserModel()
        {
            // Arrange
            var expected = Fixture.Create<User>();

            // Act
            var actual = SystemUnderTest.Map<UserModel>(expected);
            
            // Assert
            AssertEqual(expected, actual);
        }

        [Fact]
        [Trait("Category","UnitTest.Mapping")]
        public void MapUserToUserModel_Reverse()
        {
            // Arrange
            var expected = Fixture.Create<UserModel>();

            // Act
            var actual = SystemUnderTest.Map<User>(expected);

            // Assert
            AssertEqual(actual, expected);
        }

        private void AssertEqual(User user, UserModel userModel)
        {
            Assert.Equal(user.FirstName, userModel.FirstName);
            Assert.Equal(user.LastName, userModel.LastName);
            Assert.Equal(user.WorkHoursPerWeek, userModel.WorkHoursPerWeek);
            Assert.Equal(user.UserName, userModel.UserName);
            Assert.Equal(user.Email, userModel.Email);
            Assert.Equal(user.Id, userModel.Id);
        }
    }
}
