using LibraryManagementSystem.WEB.Repositories.Interfaces;
using LibraryManagementSystem.WEB.Services;
using LibraryManagementSystem.WEB.Services.Interfaces;
using LibraryManager.Site.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace LibraryManagementSystem.WEB.Components.Pages.Books
{
    public class IndexBookPage : ComponentBase
    {
        [Inject]
        public IBookService Service { get; set; } = null!;
        public List<BookViewModel> Books { get; set; }
        protected string SearchTerm = string.Empty;
        protected bool IsLoading = false;
        protected override async Task OnInitializedAsync()
        {
            await LoadBooks();
        }
        private async Task LoadBooks()
        {
            IsLoading = true;
            var result = await Service.GetAllBooks(SearchTerm);
            if (result.IsSuccess)
            {
                Books = result.Data!;
            }
            IsLoading = false;

        }
    }
}
