namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "ItemReward", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ItemReward", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
