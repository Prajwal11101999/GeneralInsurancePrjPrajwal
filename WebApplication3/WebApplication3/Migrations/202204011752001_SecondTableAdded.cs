namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationTable",
                c => new
                    {
                        Registration_ID = c.Int(nullable: false, identity: true),
                        Registration_Name = c.String(nullable: false, maxLength: 30),
                        Registration_EmailAddress = c.String(nullable: false),
                        Registration_DOB = c.DateTime(nullable: false),
                        Registration_Phone_No = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Registrartion_Address = c.String(nullable: false),
                        Registration_Password = c.String(nullable: false),
                        Registration_Confirm_Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Registration_ID);
            
            CreateTable(
                "dbo.VehicleInfoTable",
                c => new
                    {
                        Vehicle_ID = c.Int(nullable: false, identity: true),
                        Vehicle_Type = c.String(nullable: false),
                        Vehicle_Manufacturer = c.String(nullable: false),
                        Vehicle_Model = c.String(nullable: false),
                        Driving_Licence = c.String(nullable: false),
                        Vehicle_DOP = c.DateTime(nullable: false),
                        Vehicle_Regis_No = c.String(nullable: false),
                        Vehicle_Engine_No = c.String(nullable: false),
                        Vehicle_Chassis_No = c.String(nullable: false),
                        Registration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Vehicle_ID)
                .ForeignKey("dbo.RegistrationTable", t => t.Registration_Id, cascadeDelete: true)
                .Index(t => t.Registration_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleInfoTable", "Registration_Id", "dbo.RegistrationTable");
            DropIndex("dbo.VehicleInfoTable", new[] { "Registration_Id" });
            DropTable("dbo.VehicleInfoTable");
            DropTable("dbo.RegistrationTable");
        }
    }
}
