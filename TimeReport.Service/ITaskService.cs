using System;
using System.Collections.Generic;
using System.Text;
using TimeReport.Data.Entities;

namespace TimeReport.Service
{
    public interface ITaskService
    {
        IEnumerable<Task> GetTasks();
        Task GetTask(int id);
        Task InsertTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int id);
    }
}
