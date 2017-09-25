using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class BoardOfDirector
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Designation { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Educational Qualification")]
        public string EducationalQualification { get; set; }

        [Required]
        [StringLength(255)]
        public string Catagory { get; set; }

        public string Comment { get; set; }
    }
}