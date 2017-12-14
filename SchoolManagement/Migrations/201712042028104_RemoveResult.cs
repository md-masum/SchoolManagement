namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveResult : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentClasses", "FirstTerm");
            DropColumn("dbo.StudentClasses", "SecondTerm");
            DropColumn("dbo.StudentClasses", "ThirdTerm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentClasses", "ThirdTerm", c => c.Single());
            AddColumn("dbo.StudentClasses", "SecondTerm", c => c.Single());
            AddColumn("dbo.StudentClasses", "FirstTerm", c => c.Single());
        }
    }
}
