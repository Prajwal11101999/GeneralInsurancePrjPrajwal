namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsurancePlanTable",
                c => new
                    {
                        InsurancePlan_ID = c.Int(nullable: false, identity: true),
                        InsurancePlan_Type = c.String(nullable: false),
                        InsurancePlan_No_Of_Years = c.Int(nullable: false),
                        Vehicle_Id = c.Int(nullable: false),
                        Registration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsurancePlan_ID)
                .ForeignKey("dbo.RegistrationTable", t => t.Registration_Id, cascadeDelete: false)
                .ForeignKey("dbo.VehicleInfoTable", t => t.Vehicle_Id, cascadeDelete: false)
                .Index(t => t.Vehicle_Id)
                .Index(t => t.Registration_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsurancePlanTable", "Vehicle_Id", "dbo.VehicleInfoTable");
            DropForeignKey("dbo.InsurancePlanTable", "Registration_Id", "dbo.RegistrationTable");
            DropIndex("dbo.InsurancePlanTable", new[] { "Registration_Id" });
            DropIndex("dbo.InsurancePlanTable", new[] { "Vehicle_Id" });
            DropTable("dbo.InsurancePlanTable");
        }
    }
}
