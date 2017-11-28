namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditClass1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "DepartmentId", c => c.Byte());
            CreateIndex("dbo.Classes", "DepartmentId");
            AddForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Classes", new[] { "DepartmentId" });
            DropColumn("dbo.Classes", "DepartmentId");
        }
    }
}
