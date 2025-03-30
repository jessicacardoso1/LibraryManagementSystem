using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.BookAuthorCommands.InsertBookAuthor
{
    public class InsertBookAuthorCommand : IRequest<ResultViewModel<int>>
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public BookAuthor ToEntity() => new(BookId, AuthorId);

    }
}
