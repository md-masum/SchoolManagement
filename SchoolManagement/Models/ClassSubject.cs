using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class ClassSubject
    {
        public int Id { get; set; }

        
        public Class Class { get; set; }
        [Display(Name = "Class")]
        [Required]
        public int ClassId { get; set; }

        
        public Subject Subject { get; set; }
        [Display(Name = "Subject")]
        [Required]
        public int SubjectId { get; set; }
    }
}