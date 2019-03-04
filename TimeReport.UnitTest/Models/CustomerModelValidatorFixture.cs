using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.TestHelper;
using TimeReport.Web.Api.Models.Validation;
using Xunit;

namespace TimeReport.UnitTests.Models
{
    public class CustomerModelValidatorFixture
    {
        private CustomerModelValidator systemUnderTest;
        public CustomerModelValidator SystemUnderTest
        {
            get
            {
                if (systemUnderTest == null)
                {
                    systemUnderTest = new CustomerModelValidator();
                }

                return systemUnderTest;
            }
        }

        [Fact]
        [Trait("Category", "UnitTest.Model.Validation")]
        public void ShouldHaveErrorWhenNameIsNullOrEmpty()
        {
            SystemUnderTest.ShouldHaveValidationErrorFor(customerModel => customerModel.Name, null as string);
            SystemUnderTest.ShouldHaveValidationErrorFor(customerModel => customerModel.Name, "");
        }

        [Fact]
        [Trait("Category", "UnitTest.Model.Validation")]
        public void ShouldHaveErrorWhenNameLengthIsNotWithingRange()
        {
            SystemUnderTest.ShouldHaveValidationErrorFor(customerModel => customerModel.Name, "a");
            SystemUnderTest.ShouldHaveValidationErrorFor(customerModel => customerModel.Name, new string('a', 201));
        }

        [Fact]
        [Trait("Category", "UnitTest.Model.Validation")]
        public void ShouldNotHaveErrorWhenValidNameIsSpecified()
        {
            SystemUnderTest.ShouldNotHaveValidationErrorFor(customerModel => customerModel.Name, "StrongPoint");
        }
    }
}
