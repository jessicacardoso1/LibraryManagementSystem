using LibraryManagementSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.UserQueries.GetAllAuthors
{
    public class GetAllAuthorQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {
    }
}
