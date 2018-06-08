namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Registered", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Item", "ApplicationUser_Id");
            AddForeignKey("dbo.Item", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Item", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Registered");
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Item", "ApplicationUser_Id");
            DropColumn("dbo.Item", "ApplicationUserId");
        }
    }
}
