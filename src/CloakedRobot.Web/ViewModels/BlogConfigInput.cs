using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.ViewModels
{
    public class BlogConfigInput
    {
        [Display(Name = "Your name")]
        [Required]
        public string OwnerName { get; set; }

        [Display(Name = "Your email")]
        [EmailAddress]
        [Required]
        public string OwnerEmail { get; set; }

        [Display(Name = "Your password")]
        [DataType(DataType.Password)]
        public string OwnerPassword { get; set; }

        [Display(Name = "Blog Title")]
        public string BlogTitle { get; set; }

        [Display(Name = "Posts per page")]
        public int PageSize { get; set; }

        [Display(Name = "Google Analytics Key")]
        public string GoogleAnalyticsKey { get; set; }        
    }
}