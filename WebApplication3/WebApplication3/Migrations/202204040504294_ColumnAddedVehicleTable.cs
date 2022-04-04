namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnAddedVehicleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleInfoTable", "Vehicle_No_Years_Old", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleInfoTable", "Vehicle_No_Years_Old");
        }
    }
}
