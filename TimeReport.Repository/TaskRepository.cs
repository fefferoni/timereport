using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public class TaskRepository : GenericBaseRepository<Task>, IRepository<Task>
    {
        private readonly TimeReportContext context;

        public TaskRepository(TimeReportContext context) : base(context)
        {
            this.context = context;
        }
        public override IEnumerable<Task> GetAll()
        {
            return context.Tasks.Include(task => task.TimeReports).Include(task => task.Customer).AsEnumerable();
        }

        public override Task Get(int id)
        {
            return context.Tasks.Include(task => task.TimeReports).Include(task => task.Customer).SingleOrDefault(s => s.Id == id);
        }

        public override void Insert(Task entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Attach existing customer to context to prevent EF from trying to insert a new customer
            if (entity.Customer != null)
            {
                context.Attach(entity.Customer);
            }

            context.Tasks.Add(entity);
            context.SaveChanges();
        }

    }
}
