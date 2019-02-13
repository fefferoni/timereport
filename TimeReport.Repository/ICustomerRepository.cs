using System;
using System.Collections.Generic;
using System.Text;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
        IEnumerable<Customer> GetAll();
    }
}
