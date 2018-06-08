namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Int());
            AlterColumn("dbo.Item", "Visits", c => c.Int());
            AlterColumn("dbo.Item", "Returned", c => c.Boolean());
            AlterColumn("dbo.Item", "ApplicationUserId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ApplicationUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "Returned", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Item", "Visits", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "Reward", c => c.Int(nullable: false));
        }
    }
}
