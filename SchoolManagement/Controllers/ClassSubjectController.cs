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

        public ActionResult Index(int? id)
        {
            

            if (id != null)
            {
                var viewModel = new ClassSubjectViewModel
                {
                    
                    Class = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).SingleOrDefault(c => c.Id == id),
                    ClassId = (int) id,
                    Subjects = _context.Subjects.ToList(),
                    ClassSubject = _context.ClassSubjects.Include(c => c.Subject).Where(c => c.ClassId == id).ToList()
                };
                return View(viewModel);
            }
            else
            {
                if(TempData["message"] == null)
                    return HttpNotFound();

                int message = (int)TempData["message"];
                var viewData = new ClassSubjectViewModel
                {
                    Class = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).SingleOrDefault(c => c.Id == message),
                    ClassId = message,
                    Subjects = _context.Subjects.ToList(),
                    ClassSubject = _context.ClassSubjects.Include(c => c.Subject).Where(c => c.ClassId == id).ToList()
                };
                return View(viewData);
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
              int id = classSubject.ClassId;

            TempData["message"] = id;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "ClassSubject");
            }
            else
            {
                _context.ClassSubjects.Add(classSubject);
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "ClassSubject");
        }
    }
}