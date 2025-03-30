using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookLoanCommands.RegisterReturn
{
    public class RegisterReturnCommandHandler : IRequestHandler<RegisterReturnCommand, ResultViewModel>
    {
        private readonly IBookLoanRepository _bookLoanRepository;

        public RegisterReturnCommandHandler(IBookLoanRepository bookLoanRepository)
        {
            _bookLoanRepository = bookLoanRepository;
        }


        public async Task<ResultViewModel> Handle(RegisterReturnCommand request, CancellationToken cancellationToken)
        {
            var bookLoan = await _bookLoanRepository.GetByIdAsync(request.BookLoanId);
            if (bookLoan == null) ResultViewModel.Error("Loan not Found");

            bookLoan.RegisterReturn(request.ReturnDate);
            await _bookLoanRepository.UpdateAsync(bookLoan);
            return ResultViewModel.Success();

            throw new NotImplementedException();
        }
    }
}
