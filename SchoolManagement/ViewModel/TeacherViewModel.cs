using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagement.Models;

namespace SchoolManagement.ViewModel
{
    public class TeacherViewModel
    {
        public TeacherViewModel() { }

        public TeacherViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Name = user.UserName;
            Email = user.Email;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}