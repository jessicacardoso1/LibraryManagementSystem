using LibraryManagementSystem.Application.Models;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.UserQueries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
{

}