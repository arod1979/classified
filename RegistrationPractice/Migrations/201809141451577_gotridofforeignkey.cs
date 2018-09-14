namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gotridofforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "CategoryPostType_Id", "dbo.CategoryPostType");
            DropIndex("dbo.Post", new[] { "CategoryPostType_Id" });
            DropColumn("dbo.Post", "CategoryPostType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "CategoryPostType_Id", c => c.Int());
            CreateIndex("dbo.Post", "CategoryPostType_Id");
            AddForeignKey("dbo.Post", "CategoryPostType_Id", "dbo.CategoryPostType", "Id");
        }
    }
}
