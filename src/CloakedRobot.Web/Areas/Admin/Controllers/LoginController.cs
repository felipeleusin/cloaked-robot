using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Areas.Admin.Models;
using CloakedRobot.Web.Models;

namespace CloakedRobot.Web.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : AdminController
    {
        [GET("login")]
        public ActionResult Index()
        {
            return View(new LoginInput());
        }

        [POST("login")]
        public ActionResult Login(LoginInput input)
        {
            if ( !ModelState.IsValid )
            {
                return View("Index", input);
            }

            if ( BlogConfig.ValidatePassword(input.Password) && BlogConfig.OwnerEmail.Equals(input.Email) )
            {
                FormsAuthentication.SetAuthCookie(BlogConfig.OwnerEmail, false);

                return RedirectToAction("Dashboard", "Home", new { area = "Admin" });
            }

            ModelState.AddModelError("EmailOrPasswordInvalid", "Invalid credentials");
            return View("Index", input);
        }

    }
}
