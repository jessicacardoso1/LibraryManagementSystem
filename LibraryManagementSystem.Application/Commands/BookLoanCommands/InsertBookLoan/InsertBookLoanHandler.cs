using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookLoanCommands.InsertBookLoan
{
    public class InsertBookLoanHandler : IRequestHandler<InsertBookLoanCommand, ResultViewModel<int>>
    {
        private readonly IBookLoanRepository _bookLoanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public InsertBookLoanHandler(IBookLoanRepository bookLoanRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _bookLoanRepository = bookLoanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }


        public async Task<ResultViewModel<int>> Handle(InsertBookLoanCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByIdAsync(request.IdUser);
            if(user == null) ResultViewModel<int>.Error("User not found");

            var book = _bookRepository.GetByIdAsync(request.IdBook);
            if (book == null) ResultViewModel<int>.Error("Book not found");

            var bookLoan = request.ToEntity();
            await  _bookLoanRepository.AddAsync(bookLoan);

            return ResultViewModel<int>.Success(bookLoan.Id);

        }
    }
}
