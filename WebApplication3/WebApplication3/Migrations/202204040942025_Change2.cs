namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClaimInfoTable", "Claim_Reason", c => c.String(nullable: false));
            DropColumn("dbo.ClaimInfoTable", "Claim_Resion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClaimInfoTable", "Claim_Resion", c => c.String(nullable: false));
            DropColumn("dbo.ClaimInfoTable", "Claim_Reason");
        }
    }
}
