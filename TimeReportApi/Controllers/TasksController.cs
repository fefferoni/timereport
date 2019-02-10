using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeReport.Data.Entities;
using TimeReport.Service;
using TimeReport.Web.Api.Models;

namespace TimeReport.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IMapper mapper;
        

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        // GET: api/Tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> Get()
        {
            try
            {
                var results = taskService.GetTasks();
                TaskModel[] models = mapper.Map<TaskModel[]>(results);
                return models;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<TaskModel> Get(int id)
        {
            try
            {
                //var now = DateTime.Now;
                //var newTask = new Task
                //{
                //    Background = "bg",
                //    Customer = new Customer {DateCreated = now, DateModified = now, Name = "Google Inc."},
                //    Name = "The first task",
                //    DateCreated = now,
                //    DateModified = now,
                //    StartDateTime = now.AddDays(-7),
                //    EndDateTime = now.AddDays(7),
                //    Goal = "Be done with it",
                //    TimeType = TimeType.FixedPrice,
                //    TimeReports = new List<Data.Entities.TimeReport>
                //    {
                //        new Data.Entities.TimeReport
                //            {DateCreated = now, DateModified = now, Date = now.AddDays(-1).Date, TimeWorked = 2},
                //        new Data.Entities.TimeReport
                //            {DateCreated = now, DateModified = now, Date = now.Date, TimeWorked = 5}
                //    },
                //};
                //taskService.InsertTask(newTask);

                var result = taskService.GetTask(id);
                if (result == null)
                    return NotFound();
                return mapper.Map<TaskModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/Tasks
        [HttpPost]
        public void Post(string value)
        {
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
