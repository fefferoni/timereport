using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TimeReport.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeReport.Web.Api.Models.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            this.CreateMap<Task, TaskModel>();
            this.CreateMap<User, UserModel>();
        }
    }
}
