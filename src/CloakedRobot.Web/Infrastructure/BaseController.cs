using CloakedRobot.Web.Models;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloakedRobot.Web.Infrastructure
{
    public class BaseController : Controller
    {
        protected IDocumentSession RavenSession { get; set; }

        private BlogConfig blogConfig;
        public BlogConfig BlogConfig
        {
            get
            {
                if (blogConfig == null)
                {
                    using (RavenSession.Advanced.DocumentStore.AggressivelyCacheFor(TimeSpan.FromMinutes(5)))
                    {
                        blogConfig = RavenSession.Load<BlogConfig>("Blog/Config");
                    }

                    if (blogConfig == null && "welcome".Equals((string)RouteData.Values["controller"], StringComparison.OrdinalIgnoreCase) == false) // first launch
                    {
                        HttpContext.Response.Redirect("~/welcome", true);
                    }
                }
                return blogConfig;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            ViewBag.BlogConfig = BlogConfig;
        }
    }
}