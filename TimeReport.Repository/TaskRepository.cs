using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TimeReportContext context;

        public TaskRepository(TimeReportContext context)
        {
            this.context = context;
        }
        public IEnumerable<Task> GetAll()
        {
            return context.Tasks.Include(task => task.TimeReports).AsEnumerable();
        }

        public Task Get(int id)
        {
            return context.Tasks.Include(task => task.TimeReports).SingleOrDefault(s => s.Id == id);
        }
        public Task Insert(Task entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Add existing customer from context so EF does not try to insert a new customer
            if (entity.Customer != null)
            {
                entity.Customer = context.Customers.Find(entity.Customer.Id);
            }

            var result = context.Tasks.Add(entity);
            context.SaveChanges();
            return result.Entity;
        }

        public void Update(Task entity)
        {
            throw new NotImplementedException();
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.SaveChanges();
        }

        public void Delete(Task entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Tasks.Remove(entity);
            context.SaveChanges();
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
