using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("PolicyInfoTable")]
    public class PolicyInfo
    {
        [ForeignKey("RegistrationInfo")]
        // [Required(ErrorMessage = "Vehicle Type Cannot be Empty")
        public int? Registration_Id { get; set; }
        public virtual RegistrationInfo RegistrationInfo { get; set; }

        [ForeignKey("InsurancePlanInfo")]
        public int? InsurancePlan_Id { get; set; }
        public virtual InsurancePlanInfo InsurancePlanInfo { get; set; }

        [ForeignKey("VehicleInfo"), Column(Order = 0)]
        public int? Vehicle_Id { get; set; }
        public virtual VehicleInfo VehicleInfo { get; set; }

        [Key]
        [Display(Name ="Policy Number : ")]
        public int PolicyInfo_Number { get; set; }

        [Display(Name ="Policy Amount Approved : ")]
        public float Policy_Amount { get; set; }

        [Display(Name = "Policy Issued Date : ")]
        public DateTime Policy_IssuedDate { get; set; }

        [Display(Name = "Policy Expiry Date : ")]
        public DateTime Policy_ExpiryDate { get; set; }

        [Display(Name ="Policy Status")]
        public string Policy_Status { get; set; }

        [Display(Name ="Policy Reason for Rejection")]
        public string Policy_Reason { get; set; }
    }
}