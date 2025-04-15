namespace LibraryManager.Site.Models;

public class BookUpdateModel
{
    public BookUpdateModel(int id, string title, int publicationYear, string isbn, string imageUrl)
    {
        Id = id;
        Title = title;
        PublicationYear = publicationYear;
        ISBN = isbn;
        ImageUrl = imageUrl;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public int PublicationYear { get; set; } 
    public string ISBN { get; set; }
    public string ImageUrl { get; set; }
}