namespace PhoneBookData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PbUsers", "Entry_Id", "dbo.Entries");
            DropIndex("dbo.PbUsers", new[] { "Entry_Id" });
            AddColumn("dbo.Entries", "User_Id", c => c.Int());
            CreateIndex("dbo.Entries", "User_Id");
            AddForeignKey("dbo.Entries", "User_Id", "dbo.PbUsers", "Id");
            DropColumn("dbo.PbUsers", "Entry_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PbUsers", "Entry_Id", c => c.Int());
            DropForeignKey("dbo.Entries", "User_Id", "dbo.PbUsers");
            DropIndex("dbo.Entries", new[] { "User_Id" });
            DropColumn("dbo.Entries", "User_Id");
            CreateIndex("dbo.PbUsers", "Entry_Id");
            AddForeignKey("dbo.PbUsers", "Entry_Id", "dbo.Entries", "Id");
        }
    }
}
