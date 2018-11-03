namespace RegistrationPractice.Migrations.Email
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timestamp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.EmailRecipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        emailbody = c.String(nullable: false),
                        itemdescription = c.String(nullable: false),
                        IdItem = c.Int(nullable: false),
                        pid = c.String(nullable: false),
                        bid = c.String(nullable: false),
                        pidrealemailaddress = c.String(nullable: false),
                        bidrealemailaddress = c.String(nullable: false),
                        pidfakeemailaddress = c.String(),
                        bidfakeemailaddress = c.String(),
                        lostcheckbox = c.Boolean(nullable: false),
                        foundcheckbox = c.Boolean(nullable: false),
                        stolencheckbox = c.Boolean(nullable: false),
                        anonymoustipcheckbox = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fromaddress = c.String(),
                        toaddress = c.String(),
                        IdItem = c.Int(nullable: false),
                        ItemDescription = c.String(nullable: false),
                        emailbody = c.String(nullable: false),
                        subject = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        EmailId = c.Int(nullable: false),
                        APIThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FakeEmail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FakeEmailChars = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryID",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        History = c.Long(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoryID");
            DropTable("dbo.FakeEmail");
            DropTable("dbo.Email");
            DropTable("dbo.EmailRecipients");
            DropTable("dbo.__MigrationHistory");
        }
    }
}
