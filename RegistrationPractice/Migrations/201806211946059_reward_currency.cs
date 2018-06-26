namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reward_currency : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Int());
        }
    }
}
