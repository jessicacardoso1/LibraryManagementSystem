using LibraryManagementSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.BookLoans.GetBookLoanById
{
    public class GetBookLoanByIdQuery : IRequest<ResultViewModel<BookLoanViewModel>>
    {
        public GetBookLoanByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
