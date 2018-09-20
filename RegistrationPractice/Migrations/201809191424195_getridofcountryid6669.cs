namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getridofcountryid6669 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Location", name: "Country_Id", newName: "CountryId");
            RenameIndex(table: "dbo.Location", name: "IX_Country_Id", newName: "IX_CountryId");
            AddColumn("dbo.Country", "RegionText", c => c.String());
            DropColumn("dbo.Country", "LocationText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Country", "LocationText", c => c.String());
            DropColumn("dbo.Country", "RegionText");
            RenameIndex(table: "dbo.Location", name: "IX_CountryId", newName: "IX_Country_Id");
            RenameColumn(table: "dbo.Location", name: "CountryId", newName: "Country_Id");
        }
    }
}
