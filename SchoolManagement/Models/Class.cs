using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Class
    {
        public int Id { get; set; }



        public ClassInfo ClassInfo { get; set; }

        [Display(Name = "Class")]
        public byte ClassInfoId { get; set; }



        public Section Section { get; set; }

        [Display(Name = "Section")]
        public byte SectionId { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department")]
        public byte? DepartmentId { get; set; }
    }
}