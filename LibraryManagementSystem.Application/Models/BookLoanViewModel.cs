using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class BookLoanViewModel
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }

        public static BookLoanViewModel FromEntity(BookLoan bookLoan)
        {
            return new BookLoanViewModel
            {
                Id = bookLoan.Id,
                LoanDate = bookLoan.LoanDate,
                DueDate = bookLoan.DueDate,
                ReturnDate = bookLoan.ReturnDate,
                BookTitle = bookLoan.Book.Title,
                UserName = bookLoan.User.Name  
            };


        }
    }
}
