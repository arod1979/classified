namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Item", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Item", "ApplicationUserId");
            DropColumn("dbo.Item", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Item", "ApplicationUserId", c => c.Int());
            CreateIndex("dbo.Item", "ApplicationUser_Id");
            AddForeignKey("dbo.Item", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
