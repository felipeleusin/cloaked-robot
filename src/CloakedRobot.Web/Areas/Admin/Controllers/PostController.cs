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
            return View("Edit", new PostInput()
                                    {
                                        DateCreated = DateTimeOffset.Now,
                                        PublishAt = DateTimeOffset.MinValue
                                    });
        }

        [GET("post/{id:int}")]
        public ActionResult Edit(int id)
        {
            var post = RavenSession.Load<Post>(id);

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
            if (!ModelState.IsValid)
            {
                return View("Edit", input);
            }

            var now = DateTimeOffset.Now;

            var post = RavenSession.Load<Post>(input.Id) ?? new Post() {DateCreated = now };

            input.MapPropertiesToInstance(post);

            if ( input.EnqueuePublishing == true )
            {
                // Gets last unplished post
                var p =
                    RavenSession.Query<Post>().OrderByDescending(x => x.PublishAt).Take(1).Select(x => new {x.PublishAt}).FirstOrDefault();

                var lastPostDate = p == null || p.PublishAt < now ? now : p.PublishAt;

                post.PublishAt = lastPostDate.AddDays(1);
            }

            RavenSession.Store(input);
            RavenSession.SaveChanges();

            return RedirectToAction("Index");
            
        }

    }
}
