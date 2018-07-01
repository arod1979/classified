namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class posttype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostTypeText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Item", "ItemType", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "PostType_Id", c => c.Int());
            CreateIndex("dbo.Item", "PostType_Id");
            AddForeignKey("dbo.Item", "PostType_Id", "dbo.PostType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "PostType_Id", "dbo.PostType");
            DropIndex("dbo.Item", new[] { "PostType_Id" });
            DropColumn("dbo.Item", "PostType_Id");
            DropColumn("dbo.Item", "ItemType");
            DropTable("dbo.PostType");
        }
    }
}
