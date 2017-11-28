using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using SchoolManagement.Models;

namespace SchoolManagement.ViewModel
{
    public class ClassFromViewModel
    {
        public Class Class { get; set; }

        public IEnumerable<ClassInfo> ClassInfos { get; set; }

        [Required]
        [Display(Name = "Class")]
        public byte ClassInfoId { get; set; }

        public IEnumerable<Section> Sections { get; set; }

        [Required]
        [Display(Name = "Section")]
        public byte SectionId { get; set; }

        public IEnumerable<Department> Departments { get; set; }
        [Display(Name = "Department")]
        public byte? DepartmentId { get; set; }

        public IEnumerable<ClassSubject> ClassSubject { get; set; }
        public int? ClassSubjectId { get; set; }

        public IEnumerable<Subject> Subject { get; set; }
    }
}