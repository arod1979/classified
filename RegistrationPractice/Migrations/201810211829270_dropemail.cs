namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropemail : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Email");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pid = c.String(),
                        bid = c.String(),
                        pidrealemailaddress = c.String(),
                        bidrealemailaddress = c.String(),
                        pidfakeemailaddress = c.String(),
                        bidfakeemailaddress = c.String(),
                        fromaddress = c.String(nullable: false),
                        toaddress = c.String(nullable: false),
                        postid = c.Int(nullable: false),
                        emailbody = c.String(nullable: false),
                        subject = c.String(),
                        EmailId = c.Int(nullable: false),
                        APIThreadId = c.Int(nullable: false),
                        lostcheckbox = c.String(),
                        foundcheckbox = c.String(),
                        stolencheckbox = c.String(),
                        anonymoustipcheckbox = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
