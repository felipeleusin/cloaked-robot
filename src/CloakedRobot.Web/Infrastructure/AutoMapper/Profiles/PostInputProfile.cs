using AutoMapper;
using CloakedRobot.Web.Areas.Admin.Models;
using CloakedRobot.Web.Infrastructure.AutoMapper.Profiles.Resolvers;
using CloakedRobot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.Infrastructure.AutoMapper.Profiles
{
    public class PostInputProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Post, PostInput>()
                .ForMember(x => x.Id, o => o.MapFrom(m => RavenIdResolver.Resolve(m.Id)))
                .ForMember(x => x.Title, o => o.MapFrom(m => m.Title))
                .ForMember(x => x.Content, o => o.MapFrom(m => m.Content))
                .ForMember(x => x.PublishAt, o => o.MapFrom(m => m.PublishAt));

            Mapper.CreateMap<PostInput, Post>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Title, o => o.MapFrom(m => m.Title))
                .ForMember(x => x.Content, o => o.MapFrom(m => m.Content));
        }
    }
}