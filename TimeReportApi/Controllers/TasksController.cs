using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly LinkGenerator linkGenerator;

        public TasksController(ITaskService taskService, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.taskService = taskService;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
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
        public ActionResult<TaskModel> Post(TaskModel model)
        {
            try
            {
                var task = mapper.Map<Task>(model);
                taskService.InsertTask(task);

                //var location = linkGenerator.GetPathByAction("Get", "Tasks", new {id = task.Id});

                //return Created("", mapper.Map<TaskModel>(task));
                return CreatedAtAction(nameof(Get), new { id = task.Id }, model);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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