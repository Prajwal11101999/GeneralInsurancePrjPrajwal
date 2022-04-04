namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnAddedUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoTable", "User_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoTable", "User_Name");
        }
    }
}
