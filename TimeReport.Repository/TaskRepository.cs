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
            return context.Tasks.AsEnumerable();
        }

        public Task Get(int id)
        {
            return context.Tasks.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Task entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Tasks.Add(entity);
            context.SaveChanges();
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
