using LibraryManagementSystem.WEB.Models;
using LibraryManagementSystem.WEB.Repositories.Interfaces;

namespace LibraryManagementSystem.WEB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7257/api";

        public UserRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }
        public async Task<ResultViewModel> ChangePassword(string email, string code, string newPassword)
        {
            try
            {
                var body = new
                {
                    Email = email,
                    Code = code,
                    NewPassword = newPassword
                };

                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/password-recovery/change", body);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return ResultViewModel.Error(error);
                }

                return ResultViewModel.Success();
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error(ex.Message);
            }
        }
        }

        public async Task<ResultViewModel<LoginViewModel>> Login(LoginInputModel login)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/login", login);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return ResultViewModel<LoginViewModel>.Error(error);
                }

                var result = await response.Content.ReadFromJsonAsync<LoginViewModel>();
                return ResultViewModel<LoginViewModel>.Success(result!);
            }
            catch (Exception ex)
            {
                return ResultViewModel<LoginViewModel>.Error(ex.Message);
            }
        }

        public async Task<ResultViewModel> RequestPasswordRecovery(string email)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/password-recovery/request", new { Email = email });
                return ResultViewModel.Success();
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error(ex.Message);
            }
        }

        public async Task<ResultViewModel> ValidateRecoveryCode(string email, string code)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/password-recovery/validate", new { Email = email, Code = code });

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return ResultViewModel.Error(error);
                }

                return ResultViewModel.Success();
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error(ex.Message);
            }
        }
    }
}
