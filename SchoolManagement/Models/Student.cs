using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public DateTime DateOfBirthDateTime { get; set; }
        public string Hometown { get; set; }
        [Required]
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string PasportNo { get; set; }

        [Required]
        public string FatherName { get; set; }
        [Required]
        public string FatherContactNo { get; set; }
        public string FatherOccupation { get; set; }
        [Required]
        public string MotherName { get; set; }
        public string MotherContactNo { get; set; }
        public string MotherOccupation { get; set; }
        public string ParentAddress { get; set; }
        [Required]
        public string GuardianName { get; set; }
        [Required]
        public string GaurdianContactNo { get; set; }
        public string Relationship { get; set; }
        public string GuardianAddress { get; set; }

        [Required]
        public string PhoneNo { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }

        [Required]
        public string PermanentAddress { get; set; }
        public string PermanentPostOffice { get; set; }
        [Required]
        public string PermanentDistrict { get; set; }
        [Required]
        public string PermanentDivision { get; set; }
        [Required]
        public string PermanentCountry { get; set; }

        [Required]
        public string PresentAddress { get; set; }
        public string PresentPostOffice { get; set; }
        [Required]
        public string PresentDistrict { get; set; }
        [Required]
        public string PresentDivision { get; set; }
        [Required]
        public string PresentCountry { get; set; }

    }
}