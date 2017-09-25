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
    public class StaffsController : ApiController
    {
        private ApplicationDbContext _context;

        public StaffsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetStaff()
        {
            var staff =_context.Staffs.ToList().Select(Mapper.Map<Staff, StaffDto>);
            return Ok(staff);
        }

        [HttpDelete]
        public IHttpActionResult DeleteStaff(int id)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staffInDb == null)
                return NotFound();

            _context.Staffs.Remove(staffInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
