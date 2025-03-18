using LibraryManagementSystem.Core.Entities;
namespace LibraryManager.Application.Models;

public class BookDetailsViewModel
{
    public BookDetailsViewModel(int id, string title, string isbn, int publicationYear)
    {
        Id = id;
        Title = title;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }
    public string Status { get; private set; }
    public string ImageUrl { get; private set; }

    public static BookDetailsViewModel FromEntity(Book book)
    {
        return new(book.Id, book.Title, book.ISBN, book.PublicationYear);
    }
}