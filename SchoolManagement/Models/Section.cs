﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Section
    {
        public Byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}