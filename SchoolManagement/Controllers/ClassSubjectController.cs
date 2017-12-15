using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;
using SchoolManagement.ViewModel;
using System.Data.Entity;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class ClassSubjectController : Controller
    {
        private ApplicationDbContext _context;

        public ClassSubjectController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(int id)
        {
            var classes = _context.Classes.SingleOrDefault(c => c.Id == id);

            if (classes == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new ClassSubjectViewModel
                {

                    Class = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).SingleOrDefault(c => c.Id == id),
                    ClassId = id,
                    Subjects = _context.Subjects.ToList(),
                    ClassSubject = _context.ClassSubjects.Include(c => c.Subject).Where(c => c.ClassId == id).ToList()
                };
                return View(viewModel);
            } 

        }

        // GET: ClassSubject
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClassSubject classSubject)
        {
              int clsid = classSubject.ClassId;
            var student = _context.Results.Where(c => c.ClassId == clsid).Select(c => new { c.StudentId }).Distinct().ToList();
            var subject = _context.ClassSubjects.SingleOrDefault(c => c.ClassId == clsid && c.SubjectId == classSubject.SubjectId);


            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "ClassSubject", new {id = clsid});
            }
            else
            {
                if (subject == null)
                {
                    _context.ClassSubjects.Add(classSubject);

                    if (student.Any())
                    {
                        foreach (var id in student)
                        {
                            var result = new Result
                            {
                                StudentId = id.StudentId,
                                SubjectId = classSubject.SubjectId,
                                ClassId = clsid
                            };
                            _context.Results.Add(result);
                            _context.SaveChanges();
                        }
                    }
                }
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "ClassSubject", new { id = clsid });
        }
    }
}