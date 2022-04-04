using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    [Table("ClaimInfoTable")]
    public class ClaimInfo
    {
        [Key]
        public int Claim_Number { get; set; }

        [Display(Name ="Claim Date : ")]
        public DateTime Claim_Date { get; set; }

        [Required(ErrorMessage ="Claim Reason is needed for Approval")]
        [Display(Name ="Claim Reason : ")]
        public string Claim_Reason { get; set; }

        [Display(Name ="Claim Approval Status : ")]
        public string Claim_Approval_Result { get; set; }

        [Display(Name ="Claim Ammount : ")]
        public float Claim_Amount { get; set; }

        [Display(Name = "Claim Approved Ammount : ")]
        public float Claim_Approved_Amount { get; set; }

        [ForeignKey("RegistrationInfo")]
        // [Required(ErrorMessage = "Vehicle Type Cannot be Empty")]
        public int Registration_Id { get; set; }
        public virtual RegistrationInfo RegistrationInfo { get; set; }

        [ForeignKey("PolicyInfo")]
        [Display(Name = "Policy Number : ")]
        public int Policy_Number { get; set; }
        public virtual PolicyInfo PolicyInfo { get; set; }
    }
}