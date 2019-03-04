using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TimeReport.Web.Api.Models.Validation
{
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(cust => cust.Name).NotEmpty().MinimumLength(2).MaximumLength(200);
        }
    }
}
