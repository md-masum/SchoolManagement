using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class StudentClass
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Class Class { get; set; }
        public int ClassId { get; set; }
    }
}