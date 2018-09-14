namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEventType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (1, 'Raid')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (2, 'Fractal')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (3, 'GuildMission')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (4, 'StoryMission')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (5, 'WvW')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (6, 'PvP')");
        }

        public override void Down()
        {
        }
    }
}
