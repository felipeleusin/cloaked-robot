using CloakedRobot.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloakedRobot.Web.Infrastructure.AutoMapper;
using CloakedRobot.Web.Infrastructure.Extensions;
using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Models;
using CloakedRobot.Web.ViewModels;
using Raven.Client;

namespace CloakedRobot.Web.Controllers
{
    public class HomeController : BlogController
    {
        [GET("/")]
        [GET("/page/{page:int}")]
        public ActionResult Index(int page=1)
        {
            RavenQueryStatistics stats;

            var posts = RavenSession.Query<Post>()
                            .Statistics(out stats)
                            .Where(x => x.IsPublished == true )
                            .Take(BlogConfig.PageSize)
                            .OrderByDescending(x => x.DatePublished)
                            .ToList()
                            .MapTo<PostViewModel>();

            return View(posts);
        }

        [GET("/{id:int}/{slug}")]
        public ActionResult Post(int id, string slug)
        {
            var post = RavenSession.Load<Post>(id);

            if (post == null || post.IsPublished == false)
            {
                return HttpNotFound();
            }

            return View(post);
        }

    }
}
