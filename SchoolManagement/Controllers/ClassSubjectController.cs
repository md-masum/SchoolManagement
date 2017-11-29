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

        public ActionResult Index(int id)
        {
            
                var viewModel = new ClassSubjectViewModel
                {
                    
                    Class = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).SingleOrDefault(c => c.Id == id),
                    Subjects = _context.Subjects.ToList(),
                    ClassSubject = _context.ClassSubjects.Include(c => c.Subject).Where(c => c.ClassId == id).ToList()
                };
                return View(viewModel);
            
            
            

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
              int Clsid = classSubject.ClassId;

            TempData["message"] = Clsid;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "ClassSubject", new {id = Clsid});
            }
            else
            {
                _context.ClassSubjects.Add(classSubject);
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "ClassSubject", new { id = Clsid });
        }
    }
}