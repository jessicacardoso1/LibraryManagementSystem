using LibraryManagementSystem.Application.Commands.BookLoanCommands.InsertBookLoan;
using LibraryManagementSystem.Application.Commands.BookLoanCommands.RegisterReturn;
using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Application.Queries.BookLoans.GetBookLoanById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertBookLoanCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookLoanById), new { id = result.Data }, command);
        }

        [HttpPost("register-return")]
        public async Task<IActionResult> RegisterReturn([FromBody] RegisterReturnCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result);
            return NoContent();

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetBookLoanById(int id)
        { 
            var result = await _mediator.Send(new GetBookLoanByIdQuery(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

    }
}
