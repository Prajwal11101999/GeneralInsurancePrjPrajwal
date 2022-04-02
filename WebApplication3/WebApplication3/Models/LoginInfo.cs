using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage ="Email Cannot be Blank")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Password Cannot be Blank")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}