namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class time1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Visits", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "Returned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Returned", c => c.Boolean());
            AlterColumn("dbo.Item", "Visits", c => c.Int());
        }
    }
}
