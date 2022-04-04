namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoTable", "Policy_Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoTable", "Policy_Status");
        }
    }
}
