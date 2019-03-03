﻿using System;
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
            this.CreateMap<Task, TaskModel>().ReverseMap();
            this.CreateMap<UserModel, User>()
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore());
            this.CreateMap<Customer, CustomerModel>();
            this.CreateMap<Data.Entities.TimeReport, TimeReportModel>().
                ForMember(t => t.TimeWorkedInHours, o => o.MapFrom(m => m.TimeWorked)).
                ReverseMap().ForMember(t => t.TimeWorked, o => o.MapFrom(m => m.TimeWorkedInHours));
        }
    }
}
