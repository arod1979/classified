namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reward10001234 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Item", "Reward");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Reward", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
