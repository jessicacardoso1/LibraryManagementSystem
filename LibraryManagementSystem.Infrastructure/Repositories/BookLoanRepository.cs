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
    public class BookLoanRepository : IBookLoanRepository
    {
        private readonly LibraryManagementSystemDbContext _context;

        public BookLoanRepository(LibraryManagementSystemDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(BookLoan bookLoan)
        {
            await _context.BookLoan.AddAsync(bookLoan);
            await _context.SaveChangesAsync();
            return bookLoan.Id;
        }

        public async Task<BookLoan?> GetByIdAsync(int id)
        {
            var bookLoan = await _context.BookLoan
                .Include(bl => bl.Book)
                .Include(bl => bl.User)
                .SingleOrDefaultAsync(x => x.Id == id);
            return bookLoan;
        }

        public async Task UpdateAsync(BookLoan bookLoan)
        {
             _context.Update(bookLoan);
            await _context.SaveChangesAsync();
        }
    }
}
