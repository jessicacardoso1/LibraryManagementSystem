﻿using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryManagementSystemDbContext _context;

        public BooksController(LibraryManagementSystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBookInputModel createproject)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookInputModel updateproject)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return NoContent();

        }
    }
}
