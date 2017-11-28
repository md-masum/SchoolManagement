using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SchoolManagement.Models;

namespace SchoolManagement.ViewModel
{
    public class StudentClassViewModel
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public ClassSubject ClassSubject { get; set; }
        public int ClassSubjectId { get; set; }

        public IEnumerable<ClassSubject> ClassSubjects { get; set; }
        [Display(Name = "Class")]
        public int ClassSubjectsId { get; set; }

        public IEnumerable<StudentClass> StudentClass { get; set; }
        public int StudentClassId { get; set; }

        public IEnumerable<Class> Class { get; set; }
        public int ClassId { get; set; }
    }
}