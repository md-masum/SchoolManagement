namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentClasses", "ClassSubjectId", "dbo.ClassSubjects");
            DropIndex("dbo.StudentClasses", new[] { "ClassSubjectId" });
            AddColumn("dbo.StudentClasses", "ClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentClasses", "ClassId");
            AddForeignKey("dbo.StudentClasses", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
            DropColumn("dbo.StudentClasses", "ClassSubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentClasses", "ClassSubjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentClasses", "ClassId", "dbo.Classes");
            DropIndex("dbo.StudentClasses", new[] { "ClassId" });
            DropColumn("dbo.StudentClasses", "ClassId");
            CreateIndex("dbo.StudentClasses", "ClassSubjectId");
            AddForeignKey("dbo.StudentClasses", "ClassSubjectId", "dbo.ClassSubjects", "Id", cascadeDelete: true);
        }
    }
}
