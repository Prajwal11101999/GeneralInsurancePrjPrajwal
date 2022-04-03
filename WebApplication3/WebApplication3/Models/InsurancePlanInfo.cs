using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("InsurancePlanTable")]
    public class InsurancePlanInfo
    {
        [Key]
        public int InsurancePlan_ID { get; set; }

        [Required(ErrorMessage ="Insurance Type: Comprehensive or Third Party Cover is Required")]
        [Display(Name ="Insurance Plan Type : ")]
        public string InsurancePlan_Type { get; set; }

        [Required(ErrorMessage = "Insurance For Number of Years: 1 Year, 2 Years or 3 Years  is Required")]
        [Display(Name = "Insurance Plan Valid For Years: ")]
        public int InsurancePlan_No_Of_Years { get; set; }

        //[Display(Name ="VehicleInfo")]
        // public virtual int Vehicle_Id { get; set; }
        [ForeignKey("VehicleInfo"), Column(Order = 0)]
        public int? Vehicle_Id { get; set; }
        public virtual VehicleInfo VehicleInfo { get; set; }



        [ForeignKey("RegistrationInfo"), Column(Order = 1)]
        // [Required(ErrorMessage = "Vehicle Type Cannot be Empty")
        public int? Registration_Id { get; set; }
        public virtual RegistrationInfo RegistrationInfo { get; set; }


    }
}