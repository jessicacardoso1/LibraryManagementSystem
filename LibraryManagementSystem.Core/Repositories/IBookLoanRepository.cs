using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Repositories
{
    public interface IBookLoanRepository
    {
        Task<int> AddAsync(BookLoan bookLoan);
        Task<BookLoan?> GetByIdAsync(int id);
        Task UpdateAsync(BookLoan bookLoan);
    }
}
