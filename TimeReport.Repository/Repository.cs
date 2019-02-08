using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TimeReportContext context;

        public Repository(TimeReportContext context)
        {
            this.context = context;
            //entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsEnumerable();
        }

        public T Get(int id)
        {
            return context.Set<T>().SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
