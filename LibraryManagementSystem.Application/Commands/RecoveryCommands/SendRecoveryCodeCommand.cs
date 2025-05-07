using LibraryManagementSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.RecoveryCommands
{
    public class SendRecoveryCodeCommand : IRequest<ResultViewModel>
    {
        public string Email { get; set; }

        public SendRecoveryCodeCommand(string email)
        {
            Email = email;
        }
    }
}
