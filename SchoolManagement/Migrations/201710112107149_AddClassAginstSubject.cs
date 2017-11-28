namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassAginstSubject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Class_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Class_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.ClassSubjects", "Class_Id", "dbo.Classes");
            DropIndex("dbo.ClassSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.ClassSubjects", new[] { "Class_Id" });
            DropTable("dbo.ClassSubjects");
        }
    }
}
