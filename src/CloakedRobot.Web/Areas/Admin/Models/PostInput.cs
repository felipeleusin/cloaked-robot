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

        public string Permalink { get; set; }
    }
}