namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reward100012343423 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Reward", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Reward");
        }
    }
}
