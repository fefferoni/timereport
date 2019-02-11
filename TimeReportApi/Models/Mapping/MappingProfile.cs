using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TimeReport.Data.Entities;

namespace TimeReport.Web.Api.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Task, TaskModel>().ReverseMap().ForMember(t => t.Project, opt => opt.Ignore());
            this.CreateMap<User, UserModel>();
            this.CreateMap<Customer, CustomerModel>();
            this.CreateMap<Data.Entities.TimeReport, TimeReportModel>().ReverseMap().
                ForMember(t => t.TimeWorked, o => o.MapFrom(m => m.TimeWorkedInHours));
        }
    }
}
