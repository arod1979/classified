namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countrytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationText = c.String(),
                        CountryText = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Location", "Country_Id", c => c.Int());
            CreateIndex("dbo.Location", "Country_Id");
            AddForeignKey("dbo.Location", "Country_Id", "dbo.Country", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "Country_Id", "dbo.Country");
            DropIndex("dbo.Location", new[] { "Country_Id" });
            DropColumn("dbo.Location", "Country_Id");
            DropTable("dbo.Country");
        }
    }
}
