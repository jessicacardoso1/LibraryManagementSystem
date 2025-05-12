using LibraryManagementSystem.Application.Commands.RecoveryCommands;
using LibraryManagementSystem.Application.Commands.UserCommands.InsertUser;
using LibraryManagementSystem.Application.Commands.UserCommands.LoginUser;
using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Application.Queries.UserQueries.GetAllAuthors;
using LibraryManagementSystem.Application.Queries.UserQueries.GetAllUsers;
using LibraryManagementSystem.Application.Queries.UserQueries.GetUserById;
using LibraryManagementSystem.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;

        public UsersController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
            var results = await _mediator.Send(new GetAllAuthorQuery());
            if (!results.IsSuccess)
            {
                return BadRequest(results.Message);
            }

            return Ok(results);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }
        [HttpPost("password-recovery/request")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordRecovery(SendRecoveryCodeCommand command)
        {
            var result = await _mediator.Send(command);

            // Retorna sempre sucesso para não expor se o e-mail existe ou não
            return Ok(result);

        }

        [HttpPost("password-recovery/validate")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidateRecoveryCode(ValidateRecoveryCodeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            // Retorna se o código é válido
            return Ok(result);
        }

        [HttpPost("password-recovery/change")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            // Retorna se a troca foi realizada
            return Ok(result);
        }
    }
}
