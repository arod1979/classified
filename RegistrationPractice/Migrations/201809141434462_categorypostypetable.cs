namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categorypostypetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Category", "PostTypeID", "dbo.PostType");
            DropIndex("dbo.Category", new[] { "PostTypeID" });
            DropIndex("dbo.Post", new[] { "Category_Id" });
            CreateTable(
                "dbo.CategoryPostType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        PostTypeID = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.PostType", t => t.PostTypeID)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .Index(t => t.CategoryID)
                .Index(t => t.PostTypeID)
                .Index(t => t.Item_Id);
            
            AddColumn("dbo.Post", "CategoryPostType_Id", c => c.Int());
            AddColumn("dbo.Email", "pid", c => c.String());
            AddColumn("dbo.Email", "bid", c => c.String());
            AddColumn("dbo.Email", "postid", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "CategoryText", c => c.String());
            CreateIndex("dbo.Post", "CategoryPostType_Id");
            AddForeignKey("dbo.Post", "CategoryPostType_Id", "dbo.CategoryPostType", "Id");
            DropColumn("dbo.Category", "PostTypeID");
            DropColumn("dbo.Post", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Category_Id", c => c.Int());
            AddColumn("dbo.Category", "PostTypeID", c => c.Int());
            DropForeignKey("dbo.CategoryPostType", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.CategoryPostType", "PostTypeID", "dbo.PostType");
            DropForeignKey("dbo.Post", "CategoryPostType_Id", "dbo.CategoryPostType");
            DropForeignKey("dbo.CategoryPostType", "CategoryID", "dbo.Category");
            DropIndex("dbo.Post", new[] { "CategoryPostType_Id" });
            DropIndex("dbo.CategoryPostType", new[] { "Item_Id" });
            DropIndex("dbo.CategoryPostType", new[] { "PostTypeID" });
            DropIndex("dbo.CategoryPostType", new[] { "CategoryID" });
            DropColumn("dbo.Item", "CategoryText");
            DropColumn("dbo.Email", "postid");
            DropColumn("dbo.Email", "bid");
            DropColumn("dbo.Email", "pid");
            DropColumn("dbo.Post", "CategoryPostType_Id");
            DropTable("dbo.CategoryPostType");
            CreateIndex("dbo.Post", "Category_Id");
            CreateIndex("dbo.Category", "PostTypeID");
            AddForeignKey("dbo.Category", "PostTypeID", "dbo.PostType", "Id");
            AddForeignKey("dbo.Post", "Category_Id", "dbo.Category", "Id");
        }
    }
}
