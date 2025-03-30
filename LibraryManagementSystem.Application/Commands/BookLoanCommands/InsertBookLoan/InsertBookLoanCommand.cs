using Azure.Core;
using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookLoanCommands.InsertBookLoan
{
    public class InsertBookLoanCommand : IRequest<ResultViewModel<int>>
    {
        public DateTime DueDate { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }

        public BookLoan ToEntity() 
           => new(DueDate, IdUser, IdBook);
        

    }
}
