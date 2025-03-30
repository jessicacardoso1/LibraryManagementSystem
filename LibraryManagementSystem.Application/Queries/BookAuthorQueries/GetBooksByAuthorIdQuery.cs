using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.BookAuthorQueries
{
    public class GetBooksByAuthorIdQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {
        public int AuthorId { get; set; }
    }

}
