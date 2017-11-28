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
    public class StudentsController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetStudent()
        {
            var student = _context.Students.Select(s => new {s.Id, s.FirstName, s.LastName, s.NickName, s.Gender, s.PhoneNo}).ToList();
            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(c => c.Id == id);

            if (studentInDb == null)
                return NotFound();

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
