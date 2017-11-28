using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers.Api
{
    public class ClassSubjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClassSubjectsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AssignSubjectToClass(ClassSubjectDto classSubject)  
        {
            var classes = _context.Classes.Single(c => c.Id == classSubject.ClassId);

            var subjects = _context.Subjects.Where(m => classSubject.SubjectIds.Contains(m.Id)).ToList();

            foreach (var subject in subjects)
            {
                var classSubjects = new ClassSubject
                {
                    Class = classes,
                    Subject = subject
                };

                _context.ClassSubjects.Add(classSubjects);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
