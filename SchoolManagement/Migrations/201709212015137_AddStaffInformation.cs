namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Designation = c.String(nullable: false, maxLength: 255),
                        EducationalQualification = c.String(nullable: false, maxLength: 255),
                        DateOfBirth = c.DateTime(),
                        PhoneNumber = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
        }
    }
}
