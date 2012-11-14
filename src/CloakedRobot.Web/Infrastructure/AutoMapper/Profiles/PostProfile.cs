using AutoMapper;
using CloakedRobot.Web.Areas.Admin.Models;
using CloakedRobot.Web.Helpers;
using CloakedRobot.Web.Infrastructure.AutoMapper.Profiles.Resolvers;
using CloakedRobot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloakedRobot.Web.ViewModels;

namespace CloakedRobot.Web.Infrastructure.AutoMapper.Profiles
{
    public class PostProfile : AbstractProfile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Post, PostInput>()
                .ForMember(x => x.Id, o => o.MapFrom(m => RavenIdResolver.Resolve(m.Id)));

            Mapper.CreateMap<PostInput, Post>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.DateCreated, o => o.Ignore())
                .ForMember(x => x.DatePublished, o => o.Ignore());

            Mapper.CreateMap<Post, PostViewModel>()
                  .ForMember(x => x.Id, o => o.MapFrom(m => RavenIdResolver.Resolve(m.Id)))
                  .ForMember(x => x.Url,o => o.MapFrom(m => UrlHelper.Action("Post", "Home", new { id = RavenIdResolver.Resolve(m.Id), slug = m.Title.GenerateSlug() })))
                  .ForMember(x => x.Content, o => o.MapFrom(m => MarkdownResolver.Resolve(m.Content)));
        }
    }
}