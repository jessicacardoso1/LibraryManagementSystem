using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.InsertBook;

public class InsertBookHandler(IBookRepository bookRepository)
    : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();
        await bookRepository.AddAsync(book);
        
        return ResultViewModel<int>.Success(book.Id);
    }
}