using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Student
        public ActionResult Index()
        {
            var studentData = _context.Students.ToList();
            return View(studentData);
        }

        public ActionResult New()
        {
            var student = new Student();
            return View("StudentForm", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var data = student;

                return View("StudentForm", data);
            }

            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var dataInDb = _context.Students.Single(c => c.Id == student.Id);
                TryUpdateModel(dataInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            if (student == null)
                return HttpNotFound();

            return View("StudentForm", student);
        }

        public ActionResult Delete(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            if (student == null)
                return HttpNotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}