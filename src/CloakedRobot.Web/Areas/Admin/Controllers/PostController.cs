using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Areas.Admin.Models;
using CloakedRobot.Web.Infrastructure.AutoMapper;
using CloakedRobot.Web.Models;
using Raven.Client;
using Raven.Client.Linq;

namespace CloakedRobot.Web.Areas.Admin.Controllers
{
    public class PostController : AdminController
    {
        [GET("post/new")]
        public ActionResult New()
        {
            return View("Edit", new PostInput()
                                    {
                                        DateCreated = DateTimeOffset.Now,
                                        DatePublished = DateTimeOffset.MinValue,
                                        IsNewPost = true
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

            if (post.IsPublished == false)
            {
                post.DatePublished = DateTimeOffset.MinValue;
            }
            else if (post.IsPublished && post.DatePublished == DateTimeOffset.MinValue )
            {
                post.DatePublished = now;
            }

            RavenSession.Store(post);
            RavenSession.SaveChanges();

            TempData["StatusMessage"] = "Post saved!";

            return RedirectToAction("Index");
        }

        [POST("post/update-publishing")]
        public ActionResult ChangePublished(int id, bool isPublished)
        {
            var post = RavenSession.Load<Post>(id);
            if (post == null)
            {
                return HttpNotFound("Post not found");
            }

            // Unpublishing a published post
            if (post.IsPublished && !isPublished)
            {
                post.DatePublished = DateTimeOffset.MinValue;
            }
                // Publishing an unpublished post
            else if (!post.IsPublished && isPublished)
            {
                post.DatePublished = DateTimeOffset.Now;
            }

            post.IsPublished = isPublished;

            return Json(new {success = true});
        }

    }
}
