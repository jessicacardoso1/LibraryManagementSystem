using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.WEB.Models
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginViewModel
    {
        public string Token { get; set; }

        public LoginViewModel(string token)
        {
            Token = token;
        }
    }
}
