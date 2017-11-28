using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers.Api
{
    public class SubjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetSubject(string query = null)
        {
            IQueryable<Subject> subject = _context.Subjects;

            if (!String.IsNullOrWhiteSpace(query))
                subject = subject.Where(s => s.Name.Contains(query));

            var subjects = subject.ToList().Select(Mapper.Map<Subject, SubjectDto>);

                return Ok(subjects);
        }

        [HttpDelete]
        public IHttpActionResult DeleteSubject(int id)
        {
            var subjectInDb = _context.Subjects.SingleOrDefault(c => c.Id == id);

            if (subjectInDb == null)
                return NotFound();

            _context.Subjects.Remove(subjectInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
