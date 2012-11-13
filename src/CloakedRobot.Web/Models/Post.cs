using System;

namespace CloakedRobot.Web.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Permalink { get; set; }

        public DateTimeOffset PublishAt { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public bool IsPublic { get; set; }
    }
}