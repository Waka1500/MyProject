namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "UserId");
        }
    }
}
