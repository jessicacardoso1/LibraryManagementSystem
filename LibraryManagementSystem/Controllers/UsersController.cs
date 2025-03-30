using LibraryManagementSystem.Application.Commands.UserCommands.InsertUser;
using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Application.Queries.UserQueries.GetAllAuthors;
using LibraryManagementSystem.Application.Queries.UserQueries.GetAllUsers;
using LibraryManagementSystem.Application.Queries.UserQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
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

        [HttpGet("authors")]
        public async Task<IActionResult> GetAuthors()
        {
            var results = await _mediator.Send(new GetAllAuthorQuery()  );
            if (!results.IsSuccess) {
                return BadRequest(results.Message);
            }

            return Ok(results);
        }

    }
}
