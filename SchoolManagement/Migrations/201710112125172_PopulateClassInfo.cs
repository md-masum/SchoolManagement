namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateClassInfo : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (1, 'Class 1')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (2, 'Class 2')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (3, 'Class 3')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (4, 'Class 4')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (5, 'Class 5')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (6, 'Class 6')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (7, 'Class 7')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (8, 'Class 8')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (9, 'Class 9')");
            Sql("INSERT INTO ClassInfoes (Id, Name) VALUES (10, 'Class 10')");
        }
        
        public override void Down()
        {
        }
    }
}
