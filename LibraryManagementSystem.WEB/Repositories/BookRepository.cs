using LibraryManagementSystem.WEB.Models;
using LibraryManagementSystem.WEB.Repositories.Interfaces;
using LibraryManager.Site.Models;

namespace LibraryManagementSystem.WEB.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7275/api";

        public BookRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");

        }
        public async Task<ResultViewModel<int>> Add(BookCreateModel book)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/books", book);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return ResultViewModel<int>.Error(error);
                }

                var id = await response.Content.ReadFromJsonAsync<int>();
                return ResultViewModel<int>.Success(id);


            }
            catch (Exception ex)
            {
                return ResultViewModel<int>.Error(ex.Message);
            }
        }

        public async Task<ResultViewModel> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/books/{id}");
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

        public async Task<ResultViewModel<List<BookViewModel>>> GetAllBooks()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/books");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return ResultViewModel<List<BookViewModel>>.Error(error);
                }
                var books = await response.Content.ReadFromJsonAsync<List<BookViewModel>>();
                return ResultViewModel<List<BookViewModel>>.Success(books!);
            }
            catch (Exception ex)
            {
                return ResultViewModel<List<BookViewModel>>.Error(ex.Message);
            }
        }

        public async Task<ResultViewModel<BookViewModel>> GetBookById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/books/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return ResultViewModel<BookViewModel>.Error(error);
                }

                var book = await response.Content.ReadFromJsonAsync<BookViewModel>();
                return ResultViewModel<BookViewModel>.Success(book!);
            }
            catch (Exception ex)
            {
                return ResultViewModel<BookViewModel>.Error(ex.Message);
            }
        }
        public async Task<ResultViewModel> Update(BookUpdateModel book)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/books/{book.Id}", book);
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
