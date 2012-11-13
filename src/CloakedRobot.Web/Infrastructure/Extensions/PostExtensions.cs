using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloakedRobot.Web.Models;

namespace CloakedRobot.Web.Infrastructure.Extensions
{
    public static class PostExtensions
    {
        public static IQueryable<Post> WherePostIsPublished(this IQueryable<Post> query)
        {
            return query.Where(x => x.PublishAt <= DateTimeOffset.UtcNow && x.IsPublic == true);
        }
    }
}