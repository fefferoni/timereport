using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeReport.Data.Entities;
using TimeReport.Repository;

namespace TimeReport.UnitTest
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        private int currentIdentityValue = 0;

        public InMemoryRepository()
        {
            Items = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Items;
        }

        public T Get(int id)
        {
            return Items.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id == 0)
            {
                entity.Id = GetNextIdentityValue();
            }

            if (Items.Contains(entity) == false)
            {
                Items.Add(entity);
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (Items.Contains(entity) && entity.Id != 0)
            {
                // Replace item in list with same id
                Items[Items.FindIndex(ind=>ind.Id == entity.Id)] =  entity;
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (Items.Contains(entity))
            {
                Items.Remove(entity);
            }
        }

        private int GetNextIdentityValue()
        {
            return ++currentIdentityValue;
        }
    }
}
