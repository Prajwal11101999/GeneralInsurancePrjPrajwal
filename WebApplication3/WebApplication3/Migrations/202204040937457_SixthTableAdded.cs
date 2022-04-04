namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClaimInfoTable",
                c => new
                    {
                        Claim_Number = c.Int(nullable: false, identity: true),
                        Claim_Date = c.DateTime(nullable: false),
                        Claim_Resion = c.String(nullable: false),
                        Claim_Approval_Result = c.String(),
                        Claim_Approved_Amount = c.Single(nullable: false),
                        Registration_Id = c.Int(nullable: false),
                        Policy_Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Claim_Number)
                .ForeignKey("dbo.PolicyInfoTable", t => t.Policy_Number, cascadeDelete: true)
                .ForeignKey("dbo.RegistrationTable", t => t.Registration_Id, cascadeDelete: true)
                .Index(t => t.Registration_Id)
                .Index(t => t.Policy_Number);
            
            AddColumn("dbo.PolicyInfoTable", "Policy_Reason", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClaimInfoTable", "Registration_Id", "dbo.RegistrationTable");
            DropForeignKey("dbo.ClaimInfoTable", "Policy_Number", "dbo.PolicyInfoTable");
            DropIndex("dbo.ClaimInfoTable", new[] { "Policy_Number" });
            DropIndex("dbo.ClaimInfoTable", new[] { "Registration_Id" });
            DropColumn("dbo.PolicyInfoTable", "Policy_Reason");
            DropTable("dbo.ClaimInfoTable");
        }
    }
}
