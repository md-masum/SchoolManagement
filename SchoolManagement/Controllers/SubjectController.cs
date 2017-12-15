using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private ApplicationDbContext _context;

        public SubjectController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var subject = new Subject();
            return View("SubjectForm", subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                var data = subject;

                return View("SubjectForm", data);
            }

            if (subject.Id == 0)
                _context.Subjects.Add(subject);
            else
            {
                var dataInDb = _context.Subjects.Single(c => c.Id == subject.Id);

                dataInDb.Name = subject.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Subject");
        }

        public ActionResult Edit(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(c => c.Id == id);

            if (subject == null)
                return HttpNotFound();

            return View("SubjectForm", subject);
        }
    }
}