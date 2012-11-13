using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloakedRobot.Web.Areas.Admin.Models
{
    public class PostInput
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name="Post Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Publication Date")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset PublishAt { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Enqueue publishing?")]
        public bool EnqueuePublishing { get; set; }
    }
}