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
    public class CustomerToCustomerModelMappingFixture
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
        public void MapCustomerToCustomerModel()
        {
            // Arrange
            var expected = Fixture.Create<Customer>();

            // Act
            var actual = SystemUnderTest.Map<CustomerModel>(expected);
            
            // Assert
            AssertEqual(expected, actual);
        }

        private void AssertEqual(Customer customer, CustomerModel customerModel)
        {
            Assert.Equal(customer.Id, customerModel.Id);
            Assert.Equal(customer.Name, customerModel.Name);
            Assert.Equal(customer.DateCreated, customerModel.DateCreated);
            Assert.Equal(customer.DateModified, customerModel.DateModified);
        }

        [Fact]
        [Trait("Category", "UnitTest.Mapping")]
        public void MapCustomerToCustomerModel_Reverse()
        {
            // Arrange
            var expected = Fixture.Create<CustomerModel>();

            // Act
            var actual = SystemUnderTest.Map<Customer>(expected);
            
            // Assert
            AssertEqual(actual, expected);
        }
    }
}
