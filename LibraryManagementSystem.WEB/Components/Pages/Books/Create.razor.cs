using LibraryManagementSystem.WEB.Services.Interfaces;
using LibraryManager.Site.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace LibraryManagementSystem.WEB.Components.Pages.Books
{
    public class CreateBookPage : ComponentBase
    {
        [Parameter]
        public BookViewModel Book { get; set; } = new();

        [Parameter]
        public EventCallback<BookViewModel> OnSave { get; set; }

        [Parameter]
        public EventCallback OnCancel { get; set; }

        [Inject]
        public IBookService Service { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        protected MudForm Form;
        protected bool IsSubmitting = false;
        private IBrowserFile CoverImageFile;
        public string CoverImagePreview { get; private set; }

        protected async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            CoverImageFile = e.File;

            using var stream = CoverImageFile.OpenReadStream(maxAllowedSize: 1024 * 1024);
            var buffer = new byte[stream.Length];
            await stream.ReadAsync(buffer);
            CoverImagePreview = $"data:{CoverImageFile.ContentType};base64,{Convert.ToBase64String(buffer)}";
        }

        protected async Task Save()
        {
            IsSubmitting = true;

            try
            {
                // Valida o preenchimento do formulário
                if (!Form.IsValid)
                {
                    Snackbar.Add("Por favor, preencha todos os campos obrigatórios.", Severity.Warning);
                    IsSubmitting = false;
                    return;
                }

                // Faz o upload da imagem da capa, se necessário
                if (CoverImageFile != null)
                {
                    var uploadResult = await Service.UploadCoverImage(CoverImageFile);
                    if (uploadResult.IsSuccess)
                    {
                        Book.ImageUrl = uploadResult.Data; // Atualiza o URL da imagem
                    }
                    else
                    {
                        Snackbar.Add($"Erro ao fazer upload da capa: {uploadResult.Message}", Severity.Error);
                        IsSubmitting = false;
                        return;
                    }
                }

                // Verifica se os campos obrigatórios estão preenchidos
                if (string.IsNullOrWhiteSpace(Book.ISBN) ||
                    string.IsNullOrWhiteSpace(Book.Title) ||
                    string.IsNullOrWhiteSpace(Book.ImageUrl))
                {
                    Snackbar.Add("Campos obrigatórios estão faltando.", Severity.Warning);
                    IsSubmitting = false;
                    return;
                }

                // Cria ou atualiza o livro
                if (Book.Id == 0) // Criação de um novo livro
                {
                    var createResult = await Service.Add(new BookCreateModel(
                        Book.Title,
                        Book.PublicationYear,
                        Book.ISBN,
                        Book.ImageUrl
                    ));

                    if (!createResult.IsSuccess)
                    {
                        Snackbar.Add($"Erro ao criar o livro: {createResult.Message}", Severity.Error);
                    }
                    else
                    {
                        Snackbar.Add("Livro criado com sucesso!", Severity.Success);
                    }
                }
                else // Atualização de um livro existente
                {
                    var updateResult = await Service.Update(new BookUpdateModel(
                        Book.Id,
                        Book.Title,
                        Book.PublicationYear,
                        Book.ISBN,
                        Book.ImageUrl
                    ));

                    if (!updateResult.IsSuccess)
                    {
                        Snackbar.Add($"Erro ao atualizar o livro: {updateResult.Message}", Severity.Error);
                    }
                    else
                    {
                        Snackbar.Add("Livro atualizado com sucesso!", Severity.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Erro: {ex.Message}", Severity.Error);
            }
            finally
            {
                IsSubmitting = false;
                await OnSave.InvokeAsync(Book);
            }
        }
    }
}
