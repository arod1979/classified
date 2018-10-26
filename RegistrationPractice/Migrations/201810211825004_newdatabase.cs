namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Email", "Location_Id", "dbo.Location");
            DropIndex("dbo.Email", new[] { "Location_Id" });
            AddColumn("dbo.Email", "EmailId", c => c.Int(nullable: false));
            DropColumn("dbo.Email", "APIEmailId");
            DropColumn("dbo.Email", "PosterUserId");
            DropColumn("dbo.Email", "ResponderUserId");
            DropColumn("dbo.Email", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Email", "Location_Id", c => c.Int());
            AddColumn("dbo.Email", "ResponderUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Email", "PosterUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Email", "APIEmailId", c => c.Int(nullable: false));
            DropColumn("dbo.Email", "EmailId");
            CreateIndex("dbo.Email", "Location_Id");
            AddForeignKey("dbo.Email", "Location_Id", "dbo.Location", "Id");
        }
    }
}
