using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Auth;
using LibraryManagementSystem.Infrastructure.Notifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.RecoveryCommands
{
    public class ValidateRecoveryCodeCommandHandler : IRequestHandler<ValidateRecoveryCodeCommand, ResultViewModel>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public ValidateRecoveryCodeCommandHandler(IMemoryCache memoryCache, IUserRepository userRepository, IAuthService authService,
            IEmailService emailService)
        {
            _memoryCache = memoryCache;
            _userRepository = userRepository;
            _authService = authService;
            _emailService = emailService;
        }

        public async Task<ResultViewModel> Handle(ValidateRecoveryCodeCommand request, CancellationToken cancellationToken)
        {
            // Monta a chave usada para armazenar o código no cache
            var cacheKey = $"RecoveryCode:{request.Email}";

            // Tenta obter o código do cache
            if (!_memoryCache.TryGetValue(cacheKey, out string? code) || code != request.Code)
            {
                // Se o código não existir ou estiver incorreto, retorna erro genérico
                return ResultViewModel.Error("Código inválido ou expirado.");
            }
            // Caso o código esteja correto, retorna sucesso
            return ResultViewModel.Success();
        }
    }
}
