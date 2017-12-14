namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResultAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        FirstTerm = c.Single(),
                        SecondTerm = c.Single(),
                        ThirdTerm = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Results", "ClassId", "dbo.Classes");
            DropIndex("dbo.Results", new[] { "SubjectId" });
            DropIndex("dbo.Results", new[] { "ClassId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropTable("dbo.Results");
        }
    }
}
