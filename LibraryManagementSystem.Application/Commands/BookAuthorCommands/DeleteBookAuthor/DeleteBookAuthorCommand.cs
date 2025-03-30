using LibraryManagementSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookAuthorCommands.DeleteBookAuthor
{
    public class DeleteBookAuthorCommand : IRequest<ResultViewModel>
    {
        public int BookAuthorId { get; set; }

    }
}
