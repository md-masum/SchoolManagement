namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ClassSubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassSubjects", t => t.ClassSubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassSubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentClasses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentClasses", "ClassSubjectId", "dbo.ClassSubjects");
            DropIndex("dbo.StudentClasses", new[] { "ClassSubjectId" });
            DropIndex("dbo.StudentClasses", new[] { "StudentId" });
            DropTable("dbo.StudentClasses");
        }
    }
}
