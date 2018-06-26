namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noreward : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "LostOrFoundItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.Item", "NoReward", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Item", "AdditionalNotes", c => c.String(nullable: false));
            DropColumn("dbo.Item", "AdvertisedForFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "AdvertisedForFree", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Item", "AdditionalNotes", c => c.String());
            DropColumn("dbo.Item", "NoReward");
            DropColumn("dbo.Item", "LostOrFoundItem");
        }
    }
}
