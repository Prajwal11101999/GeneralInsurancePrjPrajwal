namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForthTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PolicyInfoTable",
                c => new
                    {
                        Vehicle_Id = c.Int(),
                        PolicyInfo_Number = c.Int(nullable: false, identity: true),
                        InsurancePlan_Id = c.Int(),
                        Policy_Amount = c.Single(nullable: false),
                        Policy_IssuedDate = c.DateTime(nullable: false),
                        Policy_ExpiryDate = c.DateTime(nullable: false),
                        Policy_Status = c.String(),
                    })
                .PrimaryKey(t => t.PolicyInfo_Number)
                .ForeignKey("dbo.InsurancePlanTable", t => t.InsurancePlan_Id)
                .ForeignKey("dbo.VehicleInfoTable", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id)
                .Index(t => t.InsurancePlan_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyInfoTable", "Vehicle_Id", "dbo.VehicleInfoTable");
            DropForeignKey("dbo.PolicyInfoTable", "InsurancePlan_Id", "dbo.InsurancePlanTable");
            DropIndex("dbo.PolicyInfoTable", new[] { "InsurancePlan_Id" });
            DropIndex("dbo.PolicyInfoTable", new[] { "Vehicle_Id" });
            DropTable("dbo.PolicyInfoTable");
        }
    }
}
