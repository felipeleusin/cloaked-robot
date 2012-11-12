using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Infrastructure;
using CloakedRobot.Web.Models;
using CloakedRobot.Web.ViewModels;
using CloakedRobot.Web.Infrastructure.AutoMapper;
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
            return View(new BlogConfigInput());
        }

        [POST("welcome/configure")]
        public ActionResult Configure(BlogConfigInput configInput)
        {
            var config = configInput.MapTo<BlogConfig>().SetPassword(configInput.OwnerPassword);
            config.Id = "Blog/Config";

            RavenSession.Store(config);
            RavenSession.SaveChanges();

            return Redirect("/");
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