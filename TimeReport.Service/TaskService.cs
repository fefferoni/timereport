using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using TimeReport.Data.Entities;
using TimeReport.Repository;

namespace TimeReport.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly ILogger<TaskService> logger;

        public TaskService(ITaskRepository taskRepository, ILogger<TaskService> logger)
        {
            this.taskRepository = taskRepository;
            this.logger = logger;
        }
        public IEnumerable<Task> GetTasks()
        {
            try
            {
                return taskRepository.GetAll();
            }
            catch (Exception exception)
            {
                logger.LogError($"Failed to get tasks: {exception}");
                throw;
            }
        }

        public Task GetTask(int id)
        {
            try
            {
                return taskRepository.Get(id);
            }
            catch (Exception exception)
            {
                logger.LogError($"Failed to get Task for id: {id} exception: {exception}");
                throw;
            }
        }

        public void InsertTask(Task task)
        {
            try
            {
                taskRepository.Insert(task);
                logger.LogInformation($"InsertTask {task}");
            }
            catch (Exception exception)
            {
                logger.LogError($"Failed to insert task: {exception}");
                throw;
            }
        }

        public void UpdateTask(Task task)
        {
            try
            {
                logger.LogInformation($"Updating task {task}");
                taskRepository.Update(task);
            }
            catch (Exception exception)
            {
                logger.LogError($"Failed to update task: {exception}");
                throw;
            }
        }

        public void DeleteTask(int id)
        {
            try
            {
                logger.LogInformation($"Deleting task for id: {id}");
                var task = GetTask(id);
                if (task != null)
                {
                    taskRepository.Delete(task);
                }
            }
            catch (Exception exception)
            {
                logger.LogError($"Failed to delete task: {exception}");
                throw;
            }
        }
    }
}
