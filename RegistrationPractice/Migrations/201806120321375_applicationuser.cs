namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "ApplicationUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ApplicationUserId", c => c.Int());
        }
    }
}
