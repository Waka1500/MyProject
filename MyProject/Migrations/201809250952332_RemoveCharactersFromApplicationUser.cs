namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCharactersFromApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Characters", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Characters", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Characters", "ApplicationUser_Id");
            AddForeignKey("dbo.Characters", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
