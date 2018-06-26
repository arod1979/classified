namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemRewardValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "ItemReward", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ItemReward", c => c.Single());
        }
    }
}
