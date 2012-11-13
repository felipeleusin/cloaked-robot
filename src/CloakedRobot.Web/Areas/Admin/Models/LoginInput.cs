using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.Areas.Admin.Models
{
    public class LoginInput
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email  { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}