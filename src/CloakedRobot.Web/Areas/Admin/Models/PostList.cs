using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloakedRobot.Web.Models;

namespace CloakedRobot.Web.Areas.Admin.Models
{
    public class PostList
    {
        public int CurrentPage { get; set; }

        public int TotalPosts { get; set; }

        public IList<Post> Posts { get; set; }

        public string SearchQuery { get; set; }
    }
}