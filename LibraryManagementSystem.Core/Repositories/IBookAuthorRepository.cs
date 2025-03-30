using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Repositories
{
    public interface IBookAuthorRepository
    {
        Task<int> AddAsync(BookAuthor bookAuthor);
        Task<BookAuthor?> GetByIdAsync(int id);
        Task<List<BookAuthor>> GetByBookIdAsync(int bookId);
        Task<List<BookAuthor>> GetByAuthorIdAsync(int authorId);
        Task DeleteAsync(BookAuthor bookAuthor);

    }
}
