using AutoMapper;
using CloakedRobot.Web.Models;
using CloakedRobot.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.Infrastructure.AutoMapper.Profiles
{
    public class BlogConfigProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<BlogConfigInput, BlogConfig>()
                .ForMember(x => x.OwnerEmail, o => o.MapFrom(m => m.OwnerEmail))
                .ForMember(x => x.PageSize, o => o.MapFrom(m => m.PageSize))
                .ForMember(x => x.OwnerName, o => o.MapFrom(m => m.OwnerName))
                .ForMember(x => x.BlogTitle, o => o.MapFrom(m => m.BlogTitle))
                .ForMember(x => x.GoogleAnalyticsKey, o => o.MapFrom(m => m.GoogleAnalyticsKey));
        }
    }
}