namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1235 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "ItemReward", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tests", "Description", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Tests", "LocationID", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tests", "EmailRelayAddress", c => c.String());
            AddColumn("dbo.Tests", "AdditionalNotes", c => c.String(nullable: false));
            AddColumn("dbo.Tests", "Visits", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "Returned", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tests", "OwnerUserEmail", c => c.String());
            AddColumn("dbo.Tests", "imageURL", c => c.String());
            AddColumn("dbo.Tests", "imageTitle", c => c.String());
            AddColumn("dbo.Tests", "HideItem", c => c.Boolean());
            CreateIndex("dbo.Tests", "LocationID");
            CreateIndex("dbo.Tests", "CategoryID");
            AddForeignKey("dbo.Tests", "CategoryID", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "LocationID", "dbo.Location", "Id", cascadeDelete: true);
            DropColumn("dbo.Tests", "Reward");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "Reward", c => c.Single(nullable: false));
            DropForeignKey("dbo.Tests", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Tests", "CategoryID", "dbo.Category");
            DropIndex("dbo.Tests", new[] { "CategoryID" });
            DropIndex("dbo.Tests", new[] { "LocationID" });
            DropColumn("dbo.Tests", "HideItem");
            DropColumn("dbo.Tests", "imageTitle");
            DropColumn("dbo.Tests", "imageURL");
            DropColumn("dbo.Tests", "OwnerUserEmail");
            DropColumn("dbo.Tests", "Returned");
            DropColumn("dbo.Tests", "Visits");
            DropColumn("dbo.Tests", "AdditionalNotes");
            DropColumn("dbo.Tests", "EmailRelayAddress");
            DropColumn("dbo.Tests", "CreationDate");
            DropColumn("dbo.Tests", "CategoryID");
            DropColumn("dbo.Tests", "LocationID");
            DropColumn("dbo.Tests", "Description");
            DropColumn("dbo.Tests", "ItemReward");
        }
    }
}
