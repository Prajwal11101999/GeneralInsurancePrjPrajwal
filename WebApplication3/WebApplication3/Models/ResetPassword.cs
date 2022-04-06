using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class ResetPassword
    {
        public int Registration_ID { get; set; }

        [Required(ErrorMessage = "Email Cannot be Blank")]
        [Display(Name = "Email Address : ")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        public string Registration_EmailAddress { get; set; }

        [Required(ErrorMessage = "Password Cannot be Blank")]
        [Display(Name = "Password : ")]
        // [DataType(DataType.Password)]
        public string Registration_Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Cannot be Blank")]
        [Display(Name = "Confirm Password : ")]
        // [Compare("Registration_Password", ErrorMessage = "Confirm Password should be same as Above Password.")]
        // [DataType(DataType.Password)]
        public string Registration_Confirm_Password { get; set; }
    }
}