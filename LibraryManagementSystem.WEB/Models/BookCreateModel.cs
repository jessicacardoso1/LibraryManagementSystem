namespace LibraryManager.Site.Models;

public class BookCreateModel
{
    public BookCreateModel(string title, int publicationYear, string isbn)
    {
        Title = title;
        PublicationYear = publicationYear;
        ISBN = isbn;
    }

    public string Title { get; set; }
    public int PublicationYear { get; set; } 
    public string ISBN { get; set; } 
}