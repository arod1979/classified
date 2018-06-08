namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuserid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "ApplicationUserId", c => c.Int());
            AddColumn("dbo.Item", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Item", "ApplicationUser_Id");
            AddForeignKey("dbo.Item", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Item", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Item", "ApplicationUser_Id");
            DropColumn("dbo.Item", "ApplicationUserId");
        }
    }
}
