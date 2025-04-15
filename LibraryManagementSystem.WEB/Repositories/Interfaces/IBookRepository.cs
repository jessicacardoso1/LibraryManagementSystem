using LibraryManagementSystem.WEB.Models;
using LibraryManager.Site.Models;

namespace LibraryManagementSystem.WEB.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<ResultViewModel<List<BookViewModel>>> GetAllBooks();
        Task<ResultViewModel<BookViewModel>> GetBookById(int id);
        Task<ResultViewModel<int>> Add(BookCreateModel book);
        Task<ResultViewModel> Update(BookUpdateModel book);
        Task<ResultViewModel> Delete(int id);
    }
}