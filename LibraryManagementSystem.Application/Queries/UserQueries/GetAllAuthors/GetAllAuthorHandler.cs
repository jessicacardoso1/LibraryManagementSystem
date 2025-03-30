using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.UserQueries.GetAllAuthors
{
    public class GetAllAuthorHandler : IRequestHandler<GetAllAuthorQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllAuthorHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _userRepository.GetAuthorsAsync();

            var model= authors.Select(UserViewModel.FromEntity).ToList();

            return new ResultViewModel<List<UserViewModel>>(model);
        }
    }
}
