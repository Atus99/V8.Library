using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using V8Notify.Application.Models;
using V8Notify.Domain.Models.Notify;

namespace V8Notify.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VMNotification, Notification>();
            CreateMap<Notification, VMNotification>();
        }
    }
}
