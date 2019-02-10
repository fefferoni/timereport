using System;
using System.Collections.Generic;
using System.Text;
using TimeReport.Data.Entities;

namespace TimeReport.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        Task Get(int id);
        void Insert(Task entity);
        void Update(Task entity);
        void Delete(Task entity);
        void SaveChanges();
    }
}
