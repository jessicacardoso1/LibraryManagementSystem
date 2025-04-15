using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LibraryManager.Application.Commands.BookCommands.InsertBook;

public class InsertBookCommand : IRequest<ResultViewModel<int>>
{
    public string Title { get;  set; }
    public string ISBN { get;  set; }
    public int PublicationYear { get;  set; }
    public string ImageUrl { get;  set; }
    public IFormFile CoverImage { get; set; }

    public Book ToEntity() => new(Title, ISBN, PublicationYear, ImageUrl);
}

