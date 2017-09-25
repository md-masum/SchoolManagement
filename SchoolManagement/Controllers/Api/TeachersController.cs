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
    public class TeachersController : ApiController
    {
        private ApplicationDbContext _context;

        public TeachersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetTeacher()
        {
            var teacher = _context.Teachers.ToList().Select(Mapper.Map<Teacher, TeacherDto>);
            return Ok(teacher);
        }

        [HttpDelete]
        public IHttpActionResult DeleteTeacher(int id)
        {
            var teacherInDb = _context.Teachers.SingleOrDefault(c => c.Id == id);

            if (teacherInDb == null)
                return NotFound();

            _context.Teachers.Remove(teacherInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
