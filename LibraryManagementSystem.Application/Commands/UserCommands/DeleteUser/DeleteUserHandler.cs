using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            if (user == null) return ResultViewModel<UserViewModel>.Error("User Not Found");

            user.SetAsDeleted();
            await _userRepository.Update(user);
            return ResultViewModel<UserViewModel>.Success();
        }
    }
}
