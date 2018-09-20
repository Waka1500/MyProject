using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyProject.Models;
using MyProject.Dtos;

namespace MyProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<EventDto, Event>();
            Mapper.CreateMap<EventType, EventTypeDto>();
        }
    }
}