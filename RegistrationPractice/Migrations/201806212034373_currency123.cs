namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency123 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Reward", c => c.Single(nullable: false));
        }
    }
}
