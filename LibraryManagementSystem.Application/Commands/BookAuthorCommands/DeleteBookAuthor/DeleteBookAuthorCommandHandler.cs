using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookAuthorCommands.DeleteBookAuthor
{
    public class DeleteBookAuthorCommandHandler : IRequestHandler<DeleteBookAuthorCommand, ResultViewModel>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public DeleteBookAuthorCommandHandler(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteBookAuthorCommand request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _bookAuthorRepository.GetByIdAsync(request.BookAuthorId);

            if (bookAuthor == null) return ResultViewModel.Error("Book not found.");

            await _bookAuthorRepository.DeleteAsync(bookAuthor);
            return ResultViewModel.Success();
        }
    }
}
