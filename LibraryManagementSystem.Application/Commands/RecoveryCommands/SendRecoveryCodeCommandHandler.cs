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
    public class SendRecoveryCodeCommandHandler : IRequestHandler<SendRecoveryCodeCommand, ResultViewModel>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public SendRecoveryCodeCommandHandler(IMemoryCache memoryCache, IUserRepository userRepository, IAuthService authService,
            IEmailService emailService)
        {
            _memoryCache = memoryCache;
            _userRepository = userRepository;
            _authService = authService;
            _emailService = emailService;
        }
        public async Task<ResultViewModel> Handle(SendRecoveryCodeCommand request, CancellationToken cancellationToken)
        {
            // Tenta buscar o usuário pelo e-mail
            var user = await _userRepository.GetUserByEmail(request.Email);

            // Apenas se o usuário existir, gera e envia o código
            if (user is not null)
            {
                // Gera um código de 6 dígitos
                var code = new Random().Next(100000, 999999).ToString();

                // Chave única no cache baseada no e-mail
                var cacheKey = $"RecoveryCode:{user.Email}";

                // Armazena o código no cache por 10 minutos
                _memoryCache.Set(cacheKey, code, TimeSpan.FromMinutes(10));

                // Envia o e-mail com o código
                await _emailService.SendAsync(
                    user.Email,
                    "Código de recuperação de senha",
                    $"Seu código de recuperação é: {code}");
            }

            // Retorna sucesso mesmo que o e-mail não exista (para segurança, evitar enumeração de usuários)
            return ResultViewModel.Success();
        }

    }
}
