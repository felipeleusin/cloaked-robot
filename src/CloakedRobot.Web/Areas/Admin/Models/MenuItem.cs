using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.Areas.Admin.Models
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool IsCurrent { get; set; }
        public IList<MenuItem> SubMenus { get; set; }
    }
}