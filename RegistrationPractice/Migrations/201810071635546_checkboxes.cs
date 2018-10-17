namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkboxes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Email", "pidrealemailaddress", c => c.String());
            AddColumn("dbo.Email", "bidrealemailaddress", c => c.String());
            AddColumn("dbo.Email", "pidfakeemailaddress", c => c.String());
            AddColumn("dbo.Email", "bidfakeemailaddress", c => c.String());
            AddColumn("dbo.Item", "lostcheckbox", c => c.String());
            AddColumn("dbo.Item", "foundcheckbox", c => c.String());
            AddColumn("dbo.Item", "stolencheckbox", c => c.String());
            AddColumn("dbo.Item", "anonymoustipcheckbox", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "anonymoustipcheckbox");
            DropColumn("dbo.Item", "stolencheckbox");
            DropColumn("dbo.Item", "foundcheckbox");
            DropColumn("dbo.Item", "lostcheckbox");
            DropColumn("dbo.Email", "bidfakeemailaddress");
            DropColumn("dbo.Email", "pidfakeemailaddress");
            DropColumn("dbo.Email", "bidrealemailaddress");
            DropColumn("dbo.Email", "pidrealemailaddress");
        }
    }
}
