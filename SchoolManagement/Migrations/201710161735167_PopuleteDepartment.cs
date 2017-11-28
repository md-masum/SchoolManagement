namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopuleteDepartment : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Id, Name) VALUES (1, 'Science')");
            Sql("INSERT INTO Departments (Id, Name) VALUES (2, 'Humanities')");
            Sql("INSERT INTO Departments (Id, Name) VALUES (3, 'Commerce')");
            Sql("INSERT INTO Departments (Id, Name) VALUES (4, 'Vocational')");
        }
        
        public override void Down()
        {
        }
    }
}
