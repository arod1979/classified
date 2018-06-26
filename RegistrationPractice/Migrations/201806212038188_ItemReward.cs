namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemReward : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "ItemReward", c => c.Single());
            AlterColumn("dbo.Item", "Reward", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Single());
            DropColumn("dbo.Item", "ItemReward");
        }
    }
}
