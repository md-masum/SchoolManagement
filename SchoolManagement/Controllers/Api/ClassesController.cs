using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolManagement.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace SchoolManagement.Controllers.Api
{
    public class ClassesController : ApiController
    {
        private ApplicationDbContext _context;

        public ClassesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetClass(string query = null)
        {
            var classQuery = from c in _context.Classes
                select new {Id = c.Id, Name = c.ClassInfo.Name};
            ;

            if (!String.IsNullOrWhiteSpace(query))
                classQuery = classQuery.Where(c => c.Name.Contains(query));

            var classes = classQuery.ToList();

            return Ok(classes);
        }

        public IHttpActionResult GetClass(int id)
        {
            var classes = _context.ClassInfos.SingleOrDefault(c => c.Id == id);

            if (classes == null)
                return NotFound();

            return Ok(classes);
        }
    }
}
