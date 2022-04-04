namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.UserInfoTable", "Policy_Number");
            AddForeignKey("dbo.UserInfoTable", "Policy_Number", "dbo.PolicyInfoTable", "PolicyInfo_Number", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoTable", "Policy_Number", "dbo.PolicyInfoTable");
            DropIndex("dbo.UserInfoTable", new[] { "Policy_Number" });
        }
    }
}
