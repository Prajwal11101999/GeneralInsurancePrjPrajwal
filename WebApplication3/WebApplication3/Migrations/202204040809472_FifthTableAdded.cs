namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoTable",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        Registration_Id = c.Int(nullable: false),
                        Policy_Number = c.Int(nullable: false),
                        Vehicle_Model = c.String(),
                        Vehicle_Reg_no = c.String(),
                        Policy_Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.User_Id)
                .ForeignKey("dbo.RegistrationTable", t => t.Registration_Id, cascadeDelete: true)
                .Index(t => t.Registration_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoTable", "Registration_Id", "dbo.RegistrationTable");
            DropIndex("dbo.UserInfoTable", new[] { "Registration_Id" });
            DropTable("dbo.UserInfoTable");
        }
    }
}
