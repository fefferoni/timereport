using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public class GenericBaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TimeReportContext context;
        private readonly DbSet<T> dbSet;

        public GenericBaseRepository(TimeReportContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return dbSet.FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            VerifyEntityIsAttachedToDbSet(entity);

            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            VerifyEntityIsAttachedToDbSet(entity);

            dbSet.Update(entity);
            context.SaveChanges();
        }

        protected void VerifyEntityIsAttachedToDbSet(T item)
        {
            if (item == null)
            {
                return;
            }
            var entry = context.Entry(item);

            if (entry.State == EntityState.Detached)
            {
                context.Attach(item);
            }
        }
    }
}
