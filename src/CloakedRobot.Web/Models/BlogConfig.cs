using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloakedRobot.Web.Models
{
    public class BlogConfig
    {
        public string Id { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public string BlogTitle { get; set; }

        public int PageSize { get; set; }

        public string GoogleAnalyticsKey { get; set; }
    }
}