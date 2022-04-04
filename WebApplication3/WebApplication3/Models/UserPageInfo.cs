using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("UserInfoTable")]
    public class UserPageInfo
    {
        [Key]
        public int User_Id { get; set; }

        [ForeignKey("RegistrationInfo")]
        // [Required(ErrorMessage = "Vehicle Type Cannot be Empty")]
        public int Registration_Id { get; set; }
        public virtual RegistrationInfo RegistrationInfo { get; set; }

        [Display(Name ="User Name : ")]
        public string User_Name { get; set; }

        [ForeignKey("PolicyInfo")]
        [Display(Name ="Policy Number : ")]
        public int Policy_Number { get; set; }
        public virtual PolicyInfo PolicyInfo { get; set; }

        [Display(Name = "Vehicle Number : ")]
        public string Vehicle_Model { get; set; }

        [Display(Name = "Vehicle Registration Number : ")]
        public string Vehicle_Reg_no { get; set; }

        [Display(Name = "Policy Amount : ")]
        public float Policy_Amount { get; set; }

        [Display(Name = "Policy Status : ")]
        public string Policy_Status { get; set; }

        [Display(Name = "Policy Issued Date : ")]
        public DateTime Policy_IssuedDate { get; set; }

        [Display(Name = "Policy Expiry Date : ")]
        public DateTime Policy_ExpiryDate { get; set; }
    }
}