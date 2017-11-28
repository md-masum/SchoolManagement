using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SchoolManagement.Models;
using SchoolManagement.ViewModel;
using System.Data.Entity;

namespace SchoolManagement.Controllers
{
    public class StudentClassController : Controller
    {
        private ApplicationDbContext _context;

        public StudentClassController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: StudentClass
        public ActionResult Index(int id)
        {
            var viewData = new StudentClassViewModel
            {
                Student = _context.Students.Single(c => c.Id == id),
                StudentClass = _context.StudentClasses.Include(c => c.Class.ClassInfo).Include(c => c.Class.Department).Include(c => c.Class.Section).Where(c => c.StudentId == id)
            };
            return View(viewData);
        }

        public ActionResult AddClass(int id)
        {
            var viewData = new StudentClassViewModel
            {
                Student = _context.Students.Single(c => c.Id == id),
                Class = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).ToList(),

            };
            return View("StudentClass", viewData);
        }

        public ActionResult Add(int id, int classId)
        {
            var viewData = new StudentClassViewModel
            {
                Student = _context.Students.Single(c => c.Id == id),
                StudentClass = _context.StudentClasses.Include(c => c.Class.ClassInfo).Include(c => c.Class.Department).Include(c => c.Class.Section).Where(c => c.StudentId == id)
            };

            if (id == 0)
            {
                
            }
            else if(classId == 0)
            {
                return View("Index", viewData);
            }
            else
            {
                var data = new StudentClass
                {
                    StudentId = id,
                    ClassId = classId
                };
                _context.StudentClasses.Add(data);
                _context.SaveChanges();
            }
            
            return View("Index", viewData);
        }
    }
}