namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PolicyInfoTable", "Policy_Premium", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PolicyInfoTable", "Policy_Premium");
        }
    }
}
