using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                var result = taskService.GetTask(id);
                //var reports = taskService.GetTimeReportsForTask(id).ToList();
                if (result == null)
                    return NotFound();
                return mapper.Map<TaskModel>(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/Tasks
        [HttpPost]
        public void Post([FromBody] string value)
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
