using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Site.Models;

public class BookViewModel
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
    public string Title { get; set; }

    [Range(1900, int.MaxValue, ErrorMessage = "O ano deve ser maior que 1900.")]
    public int PublicationYear { get; set; }

    [Required(ErrorMessage = "O ISBN é obrigatório.")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "O ISBN deve ter no máximo 10 caracteres.")]
    public string ISBN { get; set; }
}