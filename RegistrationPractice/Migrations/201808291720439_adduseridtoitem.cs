namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduseridtoitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Email", "PosterUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Email", "ResponderUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Email", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Email", "UserId", c => c.String());
            DropColumn("dbo.Item", "UserId");
            DropColumn("dbo.Email", "ResponderUserId");
            DropColumn("dbo.Email", "PosterUserId");
        }
    }
}
