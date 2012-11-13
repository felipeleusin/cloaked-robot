using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace CloakedRobot.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        [GET("dashboard")]
        [GET("/")]
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}
