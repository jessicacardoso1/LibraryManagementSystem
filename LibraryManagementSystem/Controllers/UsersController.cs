using DevFreela.Application.Queries.GetUserById;
using LibraryManagementSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUser)
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
