using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TimeReport.Web.Api.Models;

namespace TimeReport.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET: api/Tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> Get()
        {
            return new [] { new TaskModel { Name = "The first task" }, new TaskModel { Name = "The second task" } };
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<TaskModel> Get(int id)
        {
            return new TaskModel{ Name = $"The first task id: {id}" };
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
