using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using CloakedRobot.Web.Infrastructure;

namespace CloakedRobot.Web.Areas.Admin
{
    [Authorize]
    [RouteArea("Admin", AreaUrl = "admin")]
    public abstract class AdminController : BlogController
    {
    }
}
