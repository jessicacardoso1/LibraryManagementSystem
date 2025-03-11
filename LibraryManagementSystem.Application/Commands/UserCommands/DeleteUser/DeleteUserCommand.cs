using LibraryManagementSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
