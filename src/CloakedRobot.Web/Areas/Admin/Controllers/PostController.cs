using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Areas.Admin.Models;
using CloakedRobot.Web.Infrastructure.AutoMapper;
using CloakedRobot.Web.Models;
using Raven.Client.Linq;

namespace CloakedRobot.Web.Areas.Admin.Controllers
{
    public class PostController : AdminController
    {
        [GET("posts")]
        public ActionResult Index(int page = 1, int pageSize = 25, string sort = "PublishAt", bool sortDesc = true )
        {
            var posts = RavenSession.Advanced.LuceneQuery<Post>()
                            .AddOrder(sort, sortDesc)
                            .Skip( (page-1) * pageSize)
                            .Take( pageSize )
                            .ToList();

            return View(posts);
        }

        [GET("post/new")]
        public ActionResult New()
        {
            return View("Edit", new PostInput());
        }

        [GET("post/{id:int}")]
        public ActionResult Edit(int id)
        {
            var post = RavenSession.Load<Post>();

            if ( post == null )
            {
                return HttpNotFound("Post not found");
            }

            return View(post.MapTo<PostInput>());
        }

        [POST("post/save")]
        [ValidateInput(false)]
        public ActionResult Save(PostInput input)
        {
            throw new NotImplementedException();
        }

    }
}
