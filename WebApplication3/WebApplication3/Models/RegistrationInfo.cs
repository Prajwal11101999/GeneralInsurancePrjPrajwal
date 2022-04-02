using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("RegistrationTable")]
    public class RegistrationInfo
    {
        [Key]
        public int Registration_ID { get; set; }

        [Required(ErrorMessage = "Please Enter Full Name")]
        [Display(Name = "Full Name : ")]
        [StringLength(30, ErrorMessage = "First Name Can only be of 30 Characters")]
        public string Registration_Name { get; set; }

        [Required(ErrorMessage = "Email Cannot be Blank")]
        [Display(Name = "Email Address : ")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        public string Registration_EmailAddress { get; set; }

        [Required(ErrorMessage = "Date of Birth Cannot be Blank")]
        [Display(Name = "Date of Birth : ")]
        public DateTime Registration_DOB { get; set; }

        [Required(ErrorMessage = "Phone Number Cannot be Blank")]
        [Display(Name = "Phone Number : ")]
        [RegularExpression("^[0-9]{10}",ErrorMessage ="Must be only 10 Numbers")]
        public decimal? Registration_Phone_No { get; set; }

        [Required(ErrorMessage = "Address Cannot be Blank")]
        [Display(Name = "Address : ")]
        public string Registrartion_Address { get; set; }

        [Required(ErrorMessage = "Password Cannot be Blank")]
        [Display(Name = "Password : ")]
        [DataType(DataType.Password)]
        public string Registration_Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Cannot be Blank")]
        [Display(Name = "Confirm Password : ")]
        [Compare("Registration_Password", ErrorMessage ="Confirm Password should be same as Above Password.")]
        [DataType(DataType.Password)]
        public string Registration_Confirm_Password { get; set; }
    }
}