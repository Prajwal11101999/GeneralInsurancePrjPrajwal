using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("VehicleInfoTable")]
    public class VehicleInfo
    {
        [Key]
        public int Vehicle_ID { get; set; }

        [Required(ErrorMessage ="Vehicle Type Cannot be Empty")]
        [Display(Name = "Vehicle Type : ")]
        public string Vehicle_Type { get; set; }

        [Required(ErrorMessage = "Vehicle Manufacturer Cannot be Empty")]
        [Display(Name = "Vehicle Manufacturer Name : ")]
        public string Vehicle_Manufacturer { get; set; }

        [Required(ErrorMessage = "Vehicle Model Cannot be Empty")]
        [Display(Name = "Vehicle Model Name : ")]
        public string Vehicle_Model { get; set; }

        [Required(ErrorMessage = "Driving Licence Cannot be Empty")]
        [Display(Name = "Driving Licence : ")]
        public string Driving_Licence { get; set; }

        [Required(ErrorMessage = "Vehicle Date of Purchase Cannot be Empty")]
        [Display(Name = "Vehicle Date of Purchase : ")]
        public DateTime Vehicle_DOP { get; set; }

        [Required(ErrorMessage = "How many years has been since the Vehicle purchased is required")]
        [Display(Name = "Vehicle is how many years Old : ")]
        public float Vehicle_No_Years_Old { get; set; }

        [Required(ErrorMessage = "Vehicle Purchased Price is Required")]
        [Display(Name = "Vehicle Purchase Price : ")]
        public float Vehicle_Price { get; set; }

        [Required(ErrorMessage = "Vehicle Registration Number Cannot be Empty")]
        [Display(Name = "Vehicle Registration Number : ")]
        public string Vehicle_Regis_No { get; set; }

        [Required(ErrorMessage = "Vehicle Engine Number Cannot be Empty")]
        [Display(Name = "Vehicle Engine Number : ")]
        public string Vehicle_Engine_No { get; set; }

        [Required(ErrorMessage = "Vehicle Chassis Number Cannot be Empty")]
        [Display(Name = "Vehicle Chassis Number : ")]
        public string Vehicle_Chassis_No { get; set; }

        [ForeignKey("RegistrationInfo")]
        // [Required(ErrorMessage = "Vehicle Type Cannot be Empty")]
        public int Registration_Id { get; set; }
        public virtual RegistrationInfo RegistrationInfo { get; set; }
    }
}