namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeProblem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "Status", c => c.Boolean());
        }
    }
}
