namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reward10001234342367 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Int());
        }
    }
}
