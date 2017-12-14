namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "UserId");
        }
    }
}
