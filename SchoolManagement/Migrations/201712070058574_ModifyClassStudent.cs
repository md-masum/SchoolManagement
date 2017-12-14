namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyClassStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentClasses", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentClasses", "IsActive");
        }
    }
}
