using System;

namespace CloakedRobot.Web.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; }

        public DateTimeOffset DatePublished { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}