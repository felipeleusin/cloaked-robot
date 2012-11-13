using CloakedRobot.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloakedRobot.Web.Infrastructure.Extensions;
using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Models;

namespace CloakedRobot.Web.Controllers
{
    public class HomeController : BlogController
    {
        [GET("/")]
        public ActionResult Index()
        {
            var posts = RavenSession.Query<Post>()
                            .Where(x => x.PublishAt <= DateTimeOffset.UtcNow && x.IsPublic == true)
                            .Take(BlogConfig.PageSize)
                            .OrderByDescending(x => x.PublishAt)
                            .ToList();

            return View(posts);
        }

        [GET("/{id:int}/{slug}")]
        public ActionResult Post(int id, string slug)
        {
            var post = RavenSession.Load<Post>(id);

            if (post == null || post.PublishAt >= DateTimeOffset.UtcNow || post.IsPublic == false)
            {
                return HttpNotFound();
            }

            return View(post);
        }

    }
}
