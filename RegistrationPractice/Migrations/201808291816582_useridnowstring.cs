namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridnowstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "OwnerUserEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Item", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "OwnerUserEmail", c => c.String());
        }
    }
}
