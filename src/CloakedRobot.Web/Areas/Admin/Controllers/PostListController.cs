using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Areas.Admin.Models;
using CloakedRobot.Web.Infrastructure.Indexes;
using CloakedRobot.Web.Models;
using Raven.Client;

namespace CloakedRobot.Web.Areas.Admin.Controllers
{
    public class PostListController : AdminController
    {
        [GET("posts")]
        public ActionResult List(int page = 1, string sort = "DatePublished", bool sortDesc = true, string query = null)
        {
            RavenQueryStatistics statistics;

            var posts = RavenSession.Advanced.LuceneQuery<Post,Posts_Query>();
            
            if (!string.IsNullOrEmpty(query))
            {
                posts = posts.WhereStartsWith(x => x.Title, query);
            }

            posts = posts.AddOrder(sort, sortDesc)
                            .Skip((page - 1) * BlogConfig.PageSize)
                            .Take(BlogConfig.PageSize)
                            .Statistics(out statistics);

            return View(new PostList()
            {
                CurrentPage = page,
                Posts = posts.ToList(),
                TotalPosts = statistics.TotalResults,
                SearchQuery = query
            });
        }
    }
}
