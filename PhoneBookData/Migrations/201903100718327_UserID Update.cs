namespace PhoneBookData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIDUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PbUsers", "UserInternalId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PbUsers", "UserInternalId");
        }
    }
}
