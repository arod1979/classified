namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class founddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "FoundDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "FoundDate");
        }
    }
}
