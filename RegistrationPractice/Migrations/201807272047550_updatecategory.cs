namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "PostTypeID", c => c.Int());
            CreateIndex("dbo.Category", "PostTypeID");
            AddForeignKey("dbo.Category", "PostTypeID", "dbo.PostType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "PostTypeID", "dbo.PostType");
            DropIndex("dbo.Category", new[] { "PostTypeID" });
            DropColumn("dbo.Category", "PostTypeID");
        }
    }
}
