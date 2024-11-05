using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string iSBN, int publicationYear) : base()
        {
            Title = title;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public IList<Review> Reviews { get; private set; } = new List<Review>();
        public IList<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public void Update(string title, string iSBN, int publicationYear)
        {
            Title = title;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public void AddBookAuthor(BookAuthor bookAuthors) {
            BookAuthors.Add(bookAuthors);
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }
    }

}
