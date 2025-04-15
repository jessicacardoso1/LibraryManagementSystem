using LibraryManagementSystem.WEB.Models;
using LibraryManager.Site.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace LibraryManagementSystem.WEB.Services.Interfaces
{
    public interface IBookService
    {
        Task<ResultViewModel<List<BookViewModel>>> GetAllBooks(string? search);
        Task<ResultViewModel<BookViewModel>> GetBookById(int id);
        Task<ResultViewModel<int>> Add(BookCreateModel book);
        Task<ResultViewModel> Update(BookUpdateModel book);
        Task<ResultViewModel> Delete(int id);
        Task<ResultViewModel<string>> UploadCoverImage(IBrowserFile file);
    }
}