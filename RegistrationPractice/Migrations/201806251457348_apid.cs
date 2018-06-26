namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Item", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Item", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Item", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Item", name: "ApplicationUser_Id", newName: "ApplicationUserId");
        }
    }
}
