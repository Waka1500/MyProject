namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCharacter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        ProfessionId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professions", t => t.ProfessionId, cascadeDelete: true)
                .Index(t => t.ProfessionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "ProfessionId", "dbo.Professions");
            DropIndex("dbo.Characters", new[] { "ProfessionId" });
            DropTable("dbo.Characters");
        }
    }
}
