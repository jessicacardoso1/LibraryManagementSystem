namespace LibraryManagementSystem.WEB.Models
{
    public class LoginInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
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
