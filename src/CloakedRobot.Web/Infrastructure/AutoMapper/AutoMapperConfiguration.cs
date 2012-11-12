using AutoMapper;
using CloakedRobot.Web.Infrastructure.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.Infrastructure.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile<BlogConfigProfile>();
        }
    }
}