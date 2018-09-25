namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayNameToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Characters", "ApplicationUser_Id");
            AddForeignKey("dbo.Characters", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Characters", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "DisplayName");
            DropColumn("dbo.Characters", "ApplicationUser_Id");
        }
    }
}
