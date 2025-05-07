using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Core.Entities
{
    public class User : BaseEntity
    {
        public User() { }

        public User(string name, string email, DateTime birthdate, UserType userType, string password, string role) : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
            UserType = userType;
            Password = password;
            Role = role;
        }


        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserType UserType { get; private set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }


        public IList<BookAuthor> BookAuthors { get; private set; } = new List<BookAuthor>();

        public IList<BookLoan> BookLoans { get; private set; } = new List<BookLoan>();

        public void Update(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public void UpdatePassaword(string password)
        {
            Password = password;
        }
    }
    public enum UserType
    {
        Regular,
        Author
    }
}
