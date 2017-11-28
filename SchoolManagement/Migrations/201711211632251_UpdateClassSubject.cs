namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassSubject : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ClassSubjects", name: "Class_Id", newName: "ClassId");
            RenameColumn(table: "dbo.ClassSubjects", name: "Subject_Id", newName: "SubjectId");
            RenameIndex(table: "dbo.ClassSubjects", name: "IX_Class_Id", newName: "IX_ClassId");
            RenameIndex(table: "dbo.ClassSubjects", name: "IX_Subject_Id", newName: "IX_SubjectId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ClassSubjects", name: "IX_SubjectId", newName: "IX_Subject_Id");
            RenameIndex(table: "dbo.ClassSubjects", name: "IX_ClassId", newName: "IX_Class_Id");
            RenameColumn(table: "dbo.ClassSubjects", name: "SubjectId", newName: "Subject_Id");
            RenameColumn(table: "dbo.ClassSubjects", name: "ClassId", newName: "Class_Id");
        }
    }
}
