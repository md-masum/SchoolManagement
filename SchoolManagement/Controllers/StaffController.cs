using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext _context;

        public StaffController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var staff = new Staff();
            return View("StaffForm", staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                var data = staff;

                return View("StaffForm", data);
            }

            if (staff.Id == 0)
                _context.Staffs.Add(staff);
            else
            {
                var dataInDb = _context.Staffs.Single(c => c.Id == staff.Id);

                dataInDb.Name = staff.Name;
                dataInDb.Designation = staff.Designation;
                dataInDb.EducationalQualification = staff.EducationalQualification;
                dataInDb.DateOfBirth = staff.DateOfBirth;
                dataInDb.PhoneNumber = staff.PhoneNumber;
                dataInDb.StartDate = staff.StartDate;
                dataInDb.EndDate = staff.EndDate;
                dataInDb.Status = staff.Status;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Staff");
        }

        public ActionResult Edit(int id)
        {
            var staff = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staff == null)
                return HttpNotFound();

            return View("StaffForm", staff);
        }

    }
}