namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResult1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Results", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropIndex("dbo.Results", new[] { "ClassId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            AddColumn("dbo.StudentClasses", "FirstTerm", c => c.Single());
            AddColumn("dbo.StudentClasses", "SecondTerm", c => c.Single());
            AddColumn("dbo.StudentClasses", "ThirdTerm", c => c.Single());
            DropTable("dbo.Results");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstTerm = c.Single(),
                        SecondTerm = c.Single(),
                        ThirdTerm = c.Single(),
                        ClassId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.StudentClasses", "ThirdTerm");
            DropColumn("dbo.StudentClasses", "SecondTerm");
            DropColumn("dbo.StudentClasses", "FirstTerm");
            CreateIndex("dbo.Results", "StudentId");
            CreateIndex("dbo.Results", "ClassId");
            AddForeignKey("dbo.Results", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Results", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
