using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class GeneralInsuranceContext : DbContext
    {
        public GeneralInsuranceContext() : base("name=GeneralInsuranceDataBase")
        {

        }

        public DbSet<RegistrationInfo> RegistrationInfos { get; set; }
        public DbSet<VehicleInfo> VehicleInfos { get; set; }
        public DbSet<InsurancePlanInfo> InsurancePlanInfos { get; set; }
    }
}