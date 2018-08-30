namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fromaddress = c.String(nullable: false),
                        emailbody = c.String(nullable: false),
                        toaddress = c.String(nullable: false),
                        subject = c.String(),
                        APIEmailId = c.Int(nullable: false),
                        APIThreadId = c.Int(nullable: false),
                        UserId = c.String(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            AddColumn("dbo.AspNetUsers", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Email", "Location_Id", "dbo.Location");
            DropIndex("dbo.Email", new[] { "Location_Id" });
            DropColumn("dbo.AspNetUsers", "IsAdmin");
            DropTable("dbo.Email");
        }
    }
}
