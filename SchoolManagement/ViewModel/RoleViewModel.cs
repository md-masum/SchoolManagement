using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagement.Models;

namespace SchoolManagement.ViewModel
{
    public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}