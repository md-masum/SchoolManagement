namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        NickName = c.String(),
                        DateOfBirthDateTime = c.DateTime(nullable: false),
                        Hometown = c.String(),
                        Gender = c.String(nullable: false),
                        BloodGroup = c.String(),
                        Religion = c.String(),
                        Nationality = c.String(),
                        PasportNo = c.String(),
                        FatherName = c.String(nullable: false),
                        FatherContactNo = c.String(nullable: false),
                        FatherOccupation = c.String(),
                        MotherName = c.String(nullable: false),
                        MotherContactNo = c.String(),
                        MotherOccupation = c.String(),
                        ParentAddress = c.String(),
                        GuardianName = c.String(nullable: false),
                        GaurdianContactNo = c.String(nullable: false),
                        Relationship = c.String(),
                        GuardianAddress = c.String(),
                        PhoneNo = c.String(nullable: false),
                        PhoneNo1 = c.String(),
                        PhoneNo2 = c.String(),
                        Email = c.String(),
                        PermanentAddress = c.String(nullable: false),
                        PermanentPostOffice = c.String(),
                        PermanentDistrict = c.String(nullable: false),
                        PermanentDivision = c.String(nullable: false),
                        PermanentCountry = c.String(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PresentPostOffice = c.String(),
                        PresentDistrict = c.String(nullable: false),
                        PresentDivision = c.String(nullable: false),
                        PresentCountry = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
