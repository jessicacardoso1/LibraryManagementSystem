using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.UserQueries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll();

        var model = users.Select(UserViewModel.FromEntity).ToList();

        return new ResultViewModel<List<UserViewModel>>(model);
    }
}