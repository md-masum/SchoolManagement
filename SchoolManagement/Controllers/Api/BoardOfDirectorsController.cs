using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SchoolManagement.Dtos;
using SchoolManagement.Models;
using System.Web.Mvc;

namespace SchoolManagement.Controllers.Api
{
    public class BoardOfDirectorsController : ApiController
    {
        private ApplicationDbContext _context;

        public BoardOfDirectorsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetBoardOfDirector()
        {
            var boardOfDirector =
                _context.BoardOfDirectors.ToList().Select(Mapper.Map<BoardOfDirector, BoardOfDirectorDto>);
            return Ok(boardOfDirector);
        }

        public IHttpActionResult GetBoardOfDirector(int id)
        {
            var boardOfDirector = _context.BoardOfDirectors.SingleOrDefault(c => c.Id == id);

            if (boardOfDirector == null)
                return NotFound();

            return Ok(Mapper.Map<BoardOfDirector, BoardOfDirectorDto>(boardOfDirector));
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateBoardOfDirector(BoardOfDirectorDto boardOfDirectorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var boardOfDirector = Mapper.Map<BoardOfDirectorDto, BoardOfDirector>(boardOfDirectorDto);

            _context.BoardOfDirectors.Add(boardOfDirector);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + boardOfDirector.Id), boardOfDirectorDto);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateBoardOfDirector(int id, BoardOfDirectorDto boardOfDirectorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var boardOfDirectorInDb = _context.BoardOfDirectors.SingleOrDefault(c => c.Id == id);

            if (boardOfDirectorInDb == null)
                return NotFound();

            Mapper.Map(boardOfDirectorDto, boardOfDirectorInDb);

            _context.SaveChanges();

            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteBoardOfDirector(int id)
        {
            var boardOfDirectorInDb = _context.BoardOfDirectors.SingleOrDefault(c => c.Id == id);

            if (boardOfDirectorInDb == null)
                return NotFound();

            _context.BoardOfDirectors.Remove(boardOfDirectorInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
