namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class help1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "goat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "goat");
        }
    }
}
