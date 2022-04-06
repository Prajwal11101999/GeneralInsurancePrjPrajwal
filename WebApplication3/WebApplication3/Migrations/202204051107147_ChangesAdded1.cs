namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoTable", "Policy_Premium", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoTable", "Policy_Premium");
        }
    }
}
