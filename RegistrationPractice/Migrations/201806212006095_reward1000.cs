namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reward1000 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Single(nullable: false));
        }
    }
}
