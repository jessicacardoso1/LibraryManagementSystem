using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManager.Application.Commands.BookCommands.InsertBook;
using LibraryManager.Application.Queries.BookQueries.GetAllBooks;
using LibraryManager.Application.Queries.BookQueries.GetByIdBook;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryManagementSystemDbContext _context;
        private readonly IBookRepository _repository;
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var result = await _mediator.Send(new GetByIdBookQuery(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result.Data);
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
