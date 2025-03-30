using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class BookAuthor : BaseEntity
    {
        public BookAuthor() { }

        public BookAuthor(int idBook, int idAuthor) : base()
        {
            IdBook = idBook;
            IdAuthor = idAuthor;
        }

        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public int IdAuthor { get; private set; }
        public User Author { get; private set; }
    }
}
