namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reward666 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
