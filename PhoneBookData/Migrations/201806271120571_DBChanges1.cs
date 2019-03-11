namespace PhoneBookData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBChanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "User_Id", "dbo.PbUsers");
            DropIndex("dbo.Entries", new[] { "User_Id" });
            AddColumn("dbo.Entries", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Entries", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "User_Id", c => c.Int());
            DropColumn("dbo.Entries", "UserId");
            CreateIndex("dbo.Entries", "User_Id");
            AddForeignKey("dbo.Entries", "User_Id", "dbo.PbUsers", "Id");
        }
    }
}
