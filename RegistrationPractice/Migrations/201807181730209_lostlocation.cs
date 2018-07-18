namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lostlocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "LostLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "LostLocation");
        }
    }
}
