namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gotridofforeignkey2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "CategoryID", "dbo.CategoryPostType");
            DropForeignKey("dbo.Tests", "LocationID", "dbo.Location");
            DropIndex("dbo.Tests", new[] { "LocationID" });
            DropIndex("dbo.Tests", new[] { "CategoryID" });
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LostOrFoundItem = c.Boolean(nullable: false),
                        NoReward = c.Boolean(nullable: false),
                        ItemReward = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false, maxLength: 25),
                        LocationID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        EmailRelayAddress = c.String(),
                        AdditionalNotes = c.String(nullable: false),
                        Visits = c.Int(nullable: false),
                        Returned = c.Boolean(nullable: false),
                        OwnerUserEmail = c.String(),
                        imageURL = c.String(),
                        imageTitle = c.String(),
                        HideItem = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tests", "CategoryID");
            CreateIndex("dbo.Tests", "LocationID");
            AddForeignKey("dbo.Tests", "LocationID", "dbo.Location", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "CategoryID", "dbo.CategoryPostType", "Id", cascadeDelete: true);
        }
    }
}
