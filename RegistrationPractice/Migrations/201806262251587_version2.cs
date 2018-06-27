namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "OwnerUserEmail", c => c.String());
            AddColumn("dbo.Item", "HideItem", c => c.Boolean());
            DropColumn("dbo.Item", "UserEmail");
            DropColumn("dbo.Item", "DisplayItem");
            DropColumn("dbo.Item", "goat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "goat", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "DisplayItem", c => c.Boolean());
            AddColumn("dbo.Item", "UserEmail", c => c.String());
            DropColumn("dbo.Item", "HideItem");
            DropColumn("dbo.Item", "OwnerUserEmail");
        }
    }
}
