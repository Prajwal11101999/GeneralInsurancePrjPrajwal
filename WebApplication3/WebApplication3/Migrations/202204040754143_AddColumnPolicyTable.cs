namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPolicyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PolicyInfoTable", "Registration_Id", c => c.Int());
            CreateIndex("dbo.PolicyInfoTable", "Registration_Id");
            AddForeignKey("dbo.PolicyInfoTable", "Registration_Id", "dbo.RegistrationTable", "Registration_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyInfoTable", "Registration_Id", "dbo.RegistrationTable");
            DropIndex("dbo.PolicyInfoTable", new[] { "Registration_Id" });
            DropColumn("dbo.PolicyInfoTable", "Registration_Id");
        }
    }
}
