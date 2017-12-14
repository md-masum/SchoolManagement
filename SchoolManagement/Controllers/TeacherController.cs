using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;
using Microsoft.AspNet.Identity.Owin;

namespace SchoolManagement.Controllers
{
    public class TeacherController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public TeacherController()
        {
            _context = new ApplicationDbContext();
        }

        public TeacherController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TeacherInfo()
        {
            var teacher = _context.Teachers.ToList();
            return View(teacher);
        }

        public ActionResult New()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var user in UserManager.Users)
            {
                list.Add(new SelectListItem() { Value = user.Id, Text = user.UserName });
            }

            ViewBag.Teacher = list;


            var teacher = new Teacher();
            return View("TeacherForm", teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var user in UserManager.Users)
                {
                    list.Add(new SelectListItem() { Value = user.Id, Text = user.UserName });
                }

                ViewBag.Teacher = list;

                var data = teacher;

                return View("TeacherForm", data);
            }

            if (teacher.Id == 0)
                _context.Teachers.Add(teacher);
            else
            {
                var dataInDb = _context.Teachers.Single(c => c.Id == teacher.Id);

                dataInDb.Name = teacher.Name;
                dataInDb.Designation = teacher.Designation;
                dataInDb.EducationalQualification = teacher.EducationalQualification;
                dataInDb.DateOfBirth = teacher.DateOfBirth;
                dataInDb.PhoneNumber = teacher.PhoneNumber;
                dataInDb.StartDate = teacher.StartDate;
                dataInDb.EndDate = teacher.EndDate;
                dataInDb.Status = teacher.Status;
                dataInDb.UserId = teacher.UserId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Teacher");
        }

        public ActionResult Edit(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var user in UserManager.Users)
            {
                list.Add(new SelectListItem() { Value = user.Id, Text = user.UserName });
            }

            ViewBag.Teacher = list;

            var teacher = _context.Teachers.SingleOrDefault(c => c.Id == id);

            if (teacher == null)
                return HttpNotFound();

            return View("TeacherForm", teacher);
        }
    }
}