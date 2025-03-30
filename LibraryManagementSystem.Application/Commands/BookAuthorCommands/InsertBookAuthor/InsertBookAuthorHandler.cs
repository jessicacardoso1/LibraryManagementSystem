using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookAuthorCommands.InsertBookAuthor
{
    public class InsertBookAuthorHandler : IRequestHandler<InsertBookAuthorCommand, ResultViewModel<int>>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public InsertBookAuthorHandler(IBookAuthorRepository bookAuthorRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertBookAuthorCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book is null) ResultViewModel<int>.Error("Book not found");

            var author = await _userRepository.GetByIdAsync(request.AuthorId);
            if (author == null || author.UserType != UserType.Author)
                ResultViewModel<int>.Error("Author Invalid or not found");

            var bookAuthor = request.ToEntity();
            await _bookAuthorRepository.AddAsync(bookAuthor);

            return ResultViewModel<int>.Success(bookAuthor.Id);

        }
    }
}
