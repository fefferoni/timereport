using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeReport.Data.Entities;
using TimeReport.Repository;

namespace TimeReport.Service
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Task> taskRepository;
        private readonly IRepository<Data.Entities.TimeReport> timeReportRepository;

        public TaskService(IRepository<Task> taskRepository, IRepository<Data.Entities.TimeReport> timeReportRepository)
        {
            this.taskRepository = taskRepository;
            this.timeReportRepository = timeReportRepository;
        }
        public IEnumerable<Task> GetTasks()
        {
            return taskRepository.GetAll();
        }

        public Task GetTask(int id)
        {
            return taskRepository.Get(id);
        }

        public void InsertTask(Task task)
        {
            taskRepository.Insert(task);
        }

        public void UpdateTask(Task task)
        {
            taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            var task = GetTask(id);
            if (task != null)
            {
                taskRepository.Delete(task); 
            }
        }
    }
}
