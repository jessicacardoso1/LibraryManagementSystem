using System.Net.Http.Headers;
using LibraryManagementSystem.WEB.Models;
using LibraryManagementSystem.WEB.Repositories.Interfaces;
using LibraryManagementSystem.WEB.Services.Interfaces;
using LibraryManager.Site.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace LibraryManagementSystem.WEB.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly HttpClient _httpClient;

        public BookService(IBookRepository repository, IHttpClientFactory httpClientFactory)
        {
            _repository = repository;
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<ResultViewModel<int>> Add(BookCreateModel book)
        {
            return await _repository.Add(book);
        }

        public async Task<ResultViewModel> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ResultViewModel<List<BookViewModel>>> GetAllBooks(string? search)
        {
            var result = await _repository.GetAllBooks();
            if (!result.IsSuccess) return ResultViewModel<List<BookViewModel>>.Error(result.Message);

            var books = result.Data!;
            if (!string.IsNullOrEmpty(search))
            {
                books = books.FindAll(x => x.Title.ToLower().Contains(search.ToLower()));
            }

            return ResultViewModel<List<BookViewModel>>.Success(books);
        }

        public async Task<ResultViewModel<BookViewModel>> GetBookById(int id)
        {
            return await _repository.GetBookById(id);
        }

        public async Task<ResultViewModel> Update(BookUpdateModel book)
        {
            return await _repository.Update(book);
        }

        public async Task<ResultViewModel<string>> UploadCoverImage(IBrowserFile file)
        {
            using var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 1024 * 1024)); // Limite de 1 MB
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            content.Add(fileContent, "CoverImage", file.Name);

            var response = await _httpClient.PostAsync("https://localhost:7257/api/upload", content);
            if (response.IsSuccessStatusCode)
            {
                var imageUrl = await response.Content.ReadAsStringAsync();
                return ResultViewModel<string>.Success(imageUrl);
            }

            return ResultViewModel<string>.Error("Erro ao fazer upload da imagem.");
        }
    }
}