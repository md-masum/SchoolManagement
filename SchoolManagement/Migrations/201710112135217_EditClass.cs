namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "ClassInfoId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Classes", "ClassInfoId");
            AddForeignKey("dbo.Classes", "ClassInfoId", "dbo.ClassInfoes", "Id", cascadeDelete: true);
            DropColumn("dbo.Classes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "Name", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Classes", "ClassInfoId", "dbo.ClassInfoes");
            DropIndex("dbo.Classes", new[] { "ClassInfoId" });
            DropColumn("dbo.Classes", "ClassInfoId");
        }
    }
}
