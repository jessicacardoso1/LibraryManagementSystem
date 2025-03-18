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
    public class BookRepository : IBookRepository
    {
        private readonly LibraryManagementSystemDbContext _context;
        public BookRepository(LibraryManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var Book = await _context.Book.Where(x => !x.IsDeleted).ToListAsync();

            return Book;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await _context.Book
                .Where(x => !x.IsDeleted)
                .SingleOrDefaultAsync(b => b.Id == id);

            return book;
        }

        public async Task<int> AddAsync(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Book.Update(book);
            await _context.SaveChangesAsync();
        }

        public Task<Book?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
