using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Dtos
{
    public class ClassSubjectDto
    {
        public int ClassId { get; set; }
        public List<int> SubjectIds { get; set; }
    }
}