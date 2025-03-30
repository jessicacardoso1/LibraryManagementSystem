using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.BookAuthorQueries
{
    public class GetBooksByAuthorIdQueryHandler : IRequestHandler<GetBooksByAuthorIdQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public GetBooksByAuthorIdQueryHandler(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetBooksByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var bookAuthors = await _bookAuthorRepository.GetByAuthorIdAsync(request.AuthorId);

            // Mapeia os usuários (autores) para o ViewModel
            var usersViewModel = bookAuthors
                .Select(ba => UserViewModel.FromEntity(ba.Author))
                .ToList();

            return ResultViewModel<List<UserViewModel>>.Success(usersViewModel);
        }
    }

}
