namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacterToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Characters", "ApplicationUser_Id");
            AddForeignKey("dbo.Characters", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Characters", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Characters", "ApplicationUser_Id");
        }
    }
}
