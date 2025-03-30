using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email, DateTime birthDate, UserType userType, IList<string>? bookTitles)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            UserType = userType;
            BookTitles = bookTitles ?? new List<string>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public UserType UserType { get; private set; }

        // Adiciona uma lista de livros associados ao autor, para exibição
        public IList<string> BookTitles { get; private set; }

        // Converte uma entidade User para UserViewModel
        public static UserViewModel FromEntity(User user)
        {
            var bookTitles = user.BookAuthors?.Select(ba => ba.Book.Title).ToList();

            return new UserViewModel(
                user.Name,
                user.Email,
                user.BirthDate,
                user.UserType,
                bookTitles
            );
        }
    }
}
