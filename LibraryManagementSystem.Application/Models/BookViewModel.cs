using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string iSBN, int publicationYear) : base()
        {
            Id = id;
            Title = title;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }

        public static BookViewModel FromEntity(Book book)
        {
            return new(book.Id, book.Title, book.ISBN, book.PublicationYear);
        }
    }
}
