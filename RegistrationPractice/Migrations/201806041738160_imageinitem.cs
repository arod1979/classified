namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageinitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Image", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Item", "DisplayItem", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "DisplayItem");
            DropColumn("dbo.Item", "Image");
        }
    }
}
