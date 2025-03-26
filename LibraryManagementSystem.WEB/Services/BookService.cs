using LibraryManagementSystem.WEB.Models;
using LibraryManagementSystem.WEB.Repositories.Interfaces;
using LibraryManagementSystem.WEB.Services.Interfaces;
using LibraryManager.Site.Models;

namespace LibraryManagementSystem.WEB.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
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
            if (!result.IsSucces) return ResultViewModel<List<BookViewModel>>.Error(result.Message);

            var books = result.Data!;
            if (!string.IsNullOrEmpty(search))
            {
                books = books.FindAll(x => x.Title.ToLower().Contains(search.ToLower()));
            }

            return ResultViewModel<List<BookViewModel>>.Success(books);
        }

        public Task<ResultViewModel<BookViewModel>> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultViewModel> Update(BookUpdateModel book)
        {
           return await _repository.Update(book);
        }
    }
}
