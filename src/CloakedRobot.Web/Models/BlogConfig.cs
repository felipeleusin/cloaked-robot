using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.Models
{
    public class BlogConfig
    {
        public string BlogName { get; set; }

        public string OwnerEmail { get; set; }

        public string GoogleAnalyticsKey { get; set; }
    }
}