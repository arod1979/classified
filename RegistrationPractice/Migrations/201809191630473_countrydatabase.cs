namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countrydatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Country", "RegionAbbreviation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Country", "RegionAbbreviation");
        }
    }
}
