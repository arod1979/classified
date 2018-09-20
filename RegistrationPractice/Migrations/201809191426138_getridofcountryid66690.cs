namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getridofcountryid66690 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Country", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Country", "CountryId", c => c.Int(nullable: false));
        }
    }
}
