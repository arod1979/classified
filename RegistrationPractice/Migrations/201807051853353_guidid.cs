namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guidid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Item");
            DropColumn("dbo.Item", "Id");
            AddColumn("dbo.Item", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Item", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Item");
            DropColumn("dbo.Item", "Id");
            AddColumn("dbo.Item", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Item", "Id");
        }
    }
}
