using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManager.Application.Commands.BookCommands.DeleteBook;
using LibraryManager.Application.Commands.BookCommands.InsertBook;
using LibraryManager.Application.Commands.BookCommands.UpdateBook;
using LibraryManager.Application.Queries.BookQueries.GetAllBooks;
using LibraryManager.Application.Queries.BookQueries.GetByIdBook;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
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
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdBookQuery(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] InsertBookCommand command)
        {
            if (command.CoverImage != null && command.CoverImage.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(command.CoverImage.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest("Tipo de arquivo não permitido. Use .jpg, .jpeg, .png ou .gif.");
                }

                try
                {
                    // Caminho para salvar a imagem
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    Directory.CreateDirectory(folderPath);

                    // Gera um nome único para o arquivo
                    var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(folderPath, uniqueFileName);

                    // Salva a imagem na pasta wwwroot
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await command.CoverImage.CopyToAsync(stream);
                    }

                    // Gera a URL da imagem
                    var imageUrl = $"/images/{uniqueFileName}";
                    command.ImageUrl = imageUrl; // Define o caminho da imagem no Command
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Erro ao salvar a imagem: {ex.Message}");
                }
            }

            // Envia o comando ao CQRS para criar o livro
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result.Data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result.Message);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));
            if (!result.IsSuccess) return BadRequest(result.Message);
            return Ok(result);
        }
        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest("O arquivo é inválido.");
        //    }

        //    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        //    var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        //    if (!allowedExtensions.Contains(extension))
        //    {
        //        return BadRequest("Tipo de arquivo não permitido.");
        //    }

        //    try
        //    {
        //        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        //        Directory.CreateDirectory(folderPath);

        //        var uniqueFileName = $"{Guid.NewGuid()}{extension}";
        //        var filePath = Path.Combine(folderPath, uniqueFileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }

        //        var imageUrl = $"{Request.Scheme}://{Request.Host}/images/{uniqueFileName}";
        //        return Ok(new { Path = imageUrl });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Erro ao salvar o arquivo: {ex.Message}");
        //    }
        //}
    }
}
