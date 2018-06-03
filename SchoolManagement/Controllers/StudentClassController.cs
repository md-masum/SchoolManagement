using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SchoolManagement.Models;
using SchoolManagement.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace SchoolManagement.Controllers
{
    [Authorize]
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

        public ActionResult Update(int id)
        {
            var result = _context.Results.Include(c => c.Student).Include(c => c.Class).Include(c => c.Class.ClassInfo).SingleOrDefault(c => c.Id == id);
            return View("SubjectForm", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ResultViewModel result)
        {
            if (!ModelState.IsValid)
            {
                var data = _context.Results.Include(c => c.Student).Include(c => c.Class.ClassInfo).SingleOrDefault(c => c.Id == result.Id);

                return View("SubjectForm", data);
            }
            

            if (result.Id != 0)
            {
                var resultIndb = _context.Results.Single(c => c.Id == result.Id);

                resultIndb.FirstTerm = result.FirstTerm;
                resultIndb.SecondTerm = result.SecondTerm;
                resultIndb.ThirdTerm = result.ThirdTerm;
            }
            _context.SaveChanges();

            return RedirectToAction("Subject", "StudentClass", new {id = result.StudentId, classId = result.ClassId});
        }

        public ActionResult Add(int id, int classId)
        {
            if (id == 0)
                return HttpNotFound();
            else if(classId == 0)
                return RedirectToAction("Index", "StudentClass", new {id = id});
            else
            {
                var classSubject = _context.ClassSubjects.Where(s => s.ClassId == classId).Select(s => new { s.SubjectId }).ToList();

                var isActive = _context.StudentClasses.Where(c => c.StudentId == id).ToList();
                foreach (var active in isActive)
                {
                    if (active != null && active.IsActive == true)
                    {
                        active.IsActive = false;
                        _context.SaveChanges();
                    }
                }

                var data = new StudentClass
                    {
                        StudentId = id,
                        ClassId = classId,
                        IsActive = true
                    };

                    foreach (var subId in classSubject)
                    {
                        int subjectId = Convert.ToInt32(subId.SubjectId);
                        var resultData = new Result
                        {
                            StudentId = id,
                            ClassId = classId,
                            SubjectId = subjectId
                        };

                        _context.Results.Add(resultData);
                        _context.SaveChanges();
                    }
                    _context.StudentClasses.Add(data);
                    _context.SaveChanges();  
            }
            return RedirectToAction("Index", "StudentClass", new { id = id });
        }

        public ActionResult Subject(int id, int classId)
        {
            var data = new StudentClassViewModel
            {
                Student = _context.Students.Single(c => c.Id == id),
                ClassS = _context.Classes.Include(c => c.ClassInfo).Include(c => c.Department).Include(c => c.Section).SingleOrDefault(c => c.Id == classId),
                Results = _context.Results.Include(c => c.Subject).Where(c => c.ClassId == classId).Where(c => c.StudentId == id).ToList()
            };

            if (data.Student == null)
                return HttpNotFound();
            if (data.ClassS == null)
                return HttpNotFound();
            if (data.Results == null)
            {
                return HttpNotFound();
            }

            return View(data);
        }

        public ActionResult Delete(int id, int classId)
        {
            return RedirectToAction("Index", "StudentClass", new { id = id, classId = classId });
        }
    }
}