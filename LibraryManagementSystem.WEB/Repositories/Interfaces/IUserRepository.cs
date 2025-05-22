using LibraryManagementSystem.WEB.Models;

namespace LibraryManagementSystem.WEB.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ResultViewModel<LoginViewModel>> Login(LoginInputModel login);
        Task<ResultViewModel> RequestPasswordRecovery(string email);
        Task<ResultViewModel> ValidateRecoveryCode(string email, string code);
        Task<ResultViewModel> ChangePassword(string email, string code, string newPassword);
    }
}
