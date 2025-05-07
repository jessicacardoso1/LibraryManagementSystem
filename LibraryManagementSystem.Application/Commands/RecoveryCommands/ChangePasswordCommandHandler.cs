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
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResultViewModel>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public ChangePasswordCommandHandler(IMemoryCache memoryCache, IUserRepository userRepository, IAuthService authService,
            IEmailService emailService)
        {
            _memoryCache = memoryCache;
            _userRepository = userRepository;
            _authService = authService;
            _emailService = emailService;
        }


        public async Task<ResultViewModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            // Monta a chave usada para validar o código
            var cacheKey = $"RecoveryCode:{request.Email}";

            // Tenta obter o código do cache
            if (!_memoryCache.TryGetValue(cacheKey, out string? code) || code != request.Code)
            {
                return ResultViewModel.Error("Código inválido ou expirado.");
            }

            // Remove o código do cache após validação para evitar reuso
            _memoryCache.Remove(cacheKey);

            // Busca o usuário pelo e-mail
            var user = await _userRepository.GetUserByEmail(request.Email);

            // Se o usuário não existir, retorna erro genérico (evita exposição)
            if (user is null)
            {
                return ResultViewModel.Error("Ocorreu um erro ao alterar a senha.");
            }

            // Gera o hash da nova senha e atualiza
            var hash = _authService.ComputeHash(request.NewPassword);
            user.UpdatePassaword(hash);

            // Persiste a nova senha no repositório
            await _userRepository.UpdateAsync(user);

            return ResultViewModel.Success();
        }
    }
}
