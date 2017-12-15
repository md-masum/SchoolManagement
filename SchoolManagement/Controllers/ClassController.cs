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
    public class ClassController : Controller
    {
        private ApplicationDbContext _context;

        public ClassController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Class
        public ActionResult Index()
        {
            var classes = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).ToList();
            return View(classes);
        }

        public ActionResult New()
        {
            var classInfo = _context.ClassInfos.ToList();
            var sectionInfo = _context.Sections.ToList();
            var departmentInfo = _context.Departments.ToList();

            var viewModel = new ClassFromViewModel
            {
                Class = new Class(),
                ClassInfos = classInfo,
                Sections = sectionInfo,
                Departments = departmentInfo
            };
            return View("ClassForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var classes = _context.Classes.SingleOrDefault(c => c.Id == id);

            if (classes == null)
                return HttpNotFound();

            _context.Classes.Remove(classes);
            _context.SaveChanges();
            return RedirectToAction("Index", "Class");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Class classes)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClassFromViewModel
                {
                    Class = classes,
                    ClassInfos = _context.ClassInfos.ToList(),
                    Sections = _context.Sections.ToList(),
                    Departments = _context.Departments.ToList()
            };

                return View("ClassForm", viewModel);
            }
            else
            {
                _context.Classes.Add(classes);
            }
               

            _context.SaveChanges();

            return RedirectToAction("Index", "Class");
        }

        public ActionResult Details(int id)
        {
            var activeStudent =
                _context.StudentClasses.Where(c => c.ClassId == id).Where(c => c.IsActive).Select(c => c.StudentId);

            var viewData = new ClassFromViewModel
            {
                Class = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).SingleOrDefault(c => c.Id == id),
                ClassSubject = _context.ClassSubjects.Include(c => c.Subject).Where(c => c.ClassId == id).ToList(),
                StudentClasses = _context.StudentClasses.Include(c => c.Student).Where(c => c.ClassId == id).Where(c => c.IsActive).ToList()
            };



            if (viewData.Class == null)
                return HttpNotFound();

            return View(viewData);
        }
    }
}