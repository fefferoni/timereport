using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TimeReport.Web.Api.Models.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            this.CreateMap<Task, TaskModel>();
        }
    }
}
