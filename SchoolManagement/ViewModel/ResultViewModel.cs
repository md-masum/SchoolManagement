using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagement.Models;

namespace SchoolManagement.ViewModel
{
    public class ResultViewModel
    {
        public int Id { get; set; }

        //public bool IsActive { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public float? FirstTerm { get; set; }
        public float? SecondTerm { get; set; }
        public float? ThirdTerm { get; set; }
    }
}