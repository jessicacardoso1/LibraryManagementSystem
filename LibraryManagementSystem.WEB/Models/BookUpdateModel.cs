namespace LibraryManager.Site.Models;

public class BookUpdateModel
{
    public BookUpdateModel(int id, string title, int publicationYear, string isbn)
    {
        Id = id;
        Title = title;
        PublicationYear = publicationYear;
        ISBN = isbn;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public int PublicationYear { get; set; } 
    public string ISBN { get; set; } 
}