namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProfessions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Professions (Id, Name) VALUES (1, 'Guardian')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (2, 'Revenant')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (3, 'Warrior')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (4, 'Engineer')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (5, 'Ranger')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (6, 'Thief')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (7, 'Elementalist')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (8, 'Mesmer')");
            Sql("INSERT INTO Professions (Id, Name) VALUES (9, 'Necromancer')");
        }
        
        public override void Down()
        {
        }
    }
}
