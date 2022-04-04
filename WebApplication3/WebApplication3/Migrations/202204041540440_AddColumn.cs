namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoTable", "Policy_IssuedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserInfoTable", "Policy_ExpiryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoTable", "Policy_ExpiryDate");
            DropColumn("dbo.UserInfoTable", "Policy_IssuedDate");
        }
    }
}
