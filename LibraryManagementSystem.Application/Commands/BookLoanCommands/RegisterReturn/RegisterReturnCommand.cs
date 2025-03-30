using LibraryManagementSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookLoanCommands.RegisterReturn
{
    public class RegisterReturnCommand : IRequest<ResultViewModel>
    {
        public int BookLoanId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
