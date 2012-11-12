using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Infrastructure;
using CloakedRobot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloakedRobot.Web.Controllers
{
    public class WelcomeController : BlogController
    {
        [GET("welcome")]
        public ActionResult Index()
        {
            return View(new BlogConfig() { Id = "Blog/Config" });
        }

        [POST("welcome/configure")]
        public ActionResult Configure(BlogConfig config)
        {
            config.Id = "Blog/Config";
            RavenSession.Store(config);
            RavenSession.SaveChanges();

            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            BlogConfig config = RavenSession.Load<BlogConfig>("Blog/Config");

            if (config != null)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}