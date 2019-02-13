using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TimeReportContext context;

        public CustomerRepository(TimeReportContext context)
        {
            this.context = context;
        }

        public Customer Get(int id)
        {
            return context.Customers.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.AsEnumerable();
        }
    }
}
