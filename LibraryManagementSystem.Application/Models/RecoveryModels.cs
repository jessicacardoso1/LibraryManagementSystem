using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class PasswordRecoveyRequestInputModel
    {
        public string Email { get; set; }
    }

    public class ValidadeRecoveryCodeInputModel
    {
        public string Email { get; set; }
        public string Code { get; set; }

    }

    public class ChangePasswordInputModel {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
