namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnAddedVehicleTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleInfoTable", "Vehicle_Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleInfoTable", "Vehicle_Price");
        }
    }
}
