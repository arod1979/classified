namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Item", "Reward");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Reward", c => c.Int(nullable: false));
        }
    }
}
