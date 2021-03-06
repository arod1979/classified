namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "ItemReward", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ItemReward", c => c.Single(nullable: false));
        }
    }
}
