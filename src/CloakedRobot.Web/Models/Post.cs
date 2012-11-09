using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Web.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Introduction { get; set; }

        public string CanonicalUrl { get; set; }

        public string Slug { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset DatePublished { get; set; }

        public int ViewCount { get; set; }
            
    }
}