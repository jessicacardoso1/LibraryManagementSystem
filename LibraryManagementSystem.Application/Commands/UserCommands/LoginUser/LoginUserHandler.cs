using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeHash(request.Password);
                var user = await _userRepository.GetUserByEmailAndPassordAsync(request.Email, passwordHash);
            if (user == null)
            {
                return ResultViewModel<LoginViewModel?>.Error("User not found");
            }
            var token = _authService.GenerateToken(user.Email, user.Role);
            return ResultViewModel<LoginViewModel>.Success(new LoginViewModel(token));
        }
    }
}
