using LibraryManagementSystem.Application.Models;
using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.DeleteBook;

public class DeleteBookCommand(int id) : IRequest<ResultViewModel>
{
    public int id { get; set; } = id;
}