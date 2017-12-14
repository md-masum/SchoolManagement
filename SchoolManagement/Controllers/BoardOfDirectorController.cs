using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class BoardOfDirectorController : Controller
    {
        private ApplicationDbContext _context;

        public BoardOfDirectorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: BoardOfDirector
        public ActionResult Index()
        {
            //var boardOfdirector = _context.BoardOfDirectors.ToList();
            return View();
        }

        public ActionResult GoverningBody()
        {
            var boardOfdirector = _context.BoardOfDirectors.ToList();
            return View(boardOfdirector);
        }

        public ActionResult New()
        {
            var board = new BoardOfDirector();
            return View("BoardOfDirectorForm", board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BoardOfDirector boardOfDirector)
        {
            if (!ModelState.IsValid)
            {
                var data = boardOfDirector;

                return View("BoardOfDirectorForm", data);
            }

            if (boardOfDirector.Id == 0)
                _context.BoardOfDirectors.Add(boardOfDirector);
            else
            {
                var dataInDb = _context.BoardOfDirectors.Single(c => c.Id == boardOfDirector.Id);

                dataInDb.Name = boardOfDirector.Name;
                dataInDb.Designation = boardOfDirector.Name;
                dataInDb.EducationalQualification = boardOfDirector.EducationalQualification;
                dataInDb.Catagory = boardOfDirector.Catagory;
                dataInDb.Comment = boardOfDirector.Comment;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "BoardOfDirector");
        }

        public ActionResult Edit(int id)
        {
            var director = _context.BoardOfDirectors.SingleOrDefault(c => c.Id == id);

            if (director == null)
                return HttpNotFound();

            return View("BoardOfDirectorForm", director);
        }
    }
}