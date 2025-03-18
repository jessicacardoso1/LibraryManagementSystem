using LibraryManagementSystem.Application.Models;
using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetByIdBook;

public class GetByIdBookQuery : IRequest<ResultViewModel<BookDetailsViewModel>>
{
    public GetByIdBookQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}