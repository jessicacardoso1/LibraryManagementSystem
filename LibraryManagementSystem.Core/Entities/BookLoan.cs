using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class BookLoan : BaseEntity
    {
        public BookLoan() { }
        public BookLoan(DateTime dueDate, int idUser, int idBook) : base()
        {
            LoanDate = DateTime.Now;
            DueDate = dueDate;
            IdUser = idUser;
            IdBook = idBook;
        }

        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }

        public void RegisterReturn(DateTime returnDate)
        {
            ReturnDate = returnDate;
        }

        public void Update(DateTime loanDate, DateTime dueDate, DateTime returnDate) {
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;

        }

    }
}
