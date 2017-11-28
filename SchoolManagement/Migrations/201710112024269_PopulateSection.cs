namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSection : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sections (Id, Name) VALUES (1, 'A')");
            Sql("INSERT INTO Sections (Id, Name) VALUES (2, 'B')");
            Sql("INSERT INTO Sections (Id, Name) VALUES (3, 'C')");
            Sql("INSERT INTO Sections (Id, Name) VALUES (4, 'D')");
            Sql("INSERT INTO Sections (Id, Name) VALUES (5, 'E')");
        }
        
        public override void Down()
        {
        }
    }
}
