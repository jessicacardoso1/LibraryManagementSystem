namespace LibraryManager.Site.Models;

public class BookCreateModel
{
    public BookCreateModel(string title, int publicationYear, string isbn, string imageUrl)
    {
        Title = title;
        PublicationYear = publicationYear;
        ISBN = isbn;
        ImageUrl = imageUrl;
    }

    public string Title { get; set; }
    public int PublicationYear { get; set; } 
    public string ISBN { get; set; }

    public string ImageUrl { get; set; }
}