using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly LibraryManagementSystemDbContext _context;

        public BookAuthorRepository(LibraryManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(BookAuthor bookAuthor)
        {
            await _context.BookAuthor.AddAsync(bookAuthor);
            await _context.SaveChangesAsync();
            return bookAuthor.Id;
        }

        public async Task DeleteAsync(BookAuthor bookAuthor)
        {
             _context.BookAuthor.Remove(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookAuthor>> GetByAuthorIdAsync(int authorId)
        {
            return await _context.BookAuthor
                .Include(ba => ba.Book)
                .Where(ba => ba.IdAuthor == authorId)
                .ToListAsync();
        }

        public async Task<List<BookAuthor>> GetByBookIdAsync(int bookId)
        {
            return await _context.BookAuthor
                .Include(ba => ba.Author)
                .Where(ba => ba.IdBook == bookId)
                .ToListAsync();
        }

        public async Task<BookAuthor?> GetByIdAsync(int id)
        {
            return await _context.BookAuthor
               .Include(ba => ba.Book)
               .Include(ba => ba.Author)
               .FirstOrDefaultAsync(ba => ba.Id == id);
        }
    }
}
