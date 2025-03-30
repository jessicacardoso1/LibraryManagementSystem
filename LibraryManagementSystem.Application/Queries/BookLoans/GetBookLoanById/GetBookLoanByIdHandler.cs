using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.BookLoans.GetBookLoanById
{
    public class GetBookLoanByIdHandler : IRequestHandler<GetBookLoanByIdQuery, ResultViewModel<BookLoanViewModel>>
    {
        private readonly IBookLoanRepository _bookLoanRepository;

        public GetBookLoanByIdHandler(IBookLoanRepository bookLoanRepository)
        {
            _bookLoanRepository = bookLoanRepository;
        }

        public async Task<ResultViewModel<BookLoanViewModel>> Handle(GetBookLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var bookLoan = await _bookLoanRepository.GetByIdAsync(request.Id);
            if (bookLoan == null) ResultViewModel<BookLoanViewModel>.Error("Loan not found");

            var model = BookLoanViewModel.FromEntity(bookLoan);
            return ResultViewModel<BookLoanViewModel>.Success(model);
        }
    }
}
