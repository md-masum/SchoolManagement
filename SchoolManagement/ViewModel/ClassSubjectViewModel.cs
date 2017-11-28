using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SchoolManagement.Models;

namespace SchoolManagement.ViewModel
{
    public class ClassSubjectViewModel
    {
        public Class Class { get; set; }
        [Display(Name = "Class")]
        public int ClassId { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }
        [Display(Name = "Subject")]
        public int? SubjectId { get; set; }

        public IEnumerable<ClassSubject> ClassSubject { get; set; }
        public int? ClassSubjectId { get; set; }
    }
}