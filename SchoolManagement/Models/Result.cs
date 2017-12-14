using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Result
    {
        public int Id { get; set; }

        //public bool IsActive { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Class Class { get; set; }
        public int ClassId { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public float? FirstTerm { get; set; }
        public float? SecondTerm { get; set; }
        public float? ThirdTerm { get; set; }


    }
}