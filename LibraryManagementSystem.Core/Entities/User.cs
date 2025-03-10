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
        public User(string name, string email, DateTime birthdate) : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public DateTime BirthDate { get; set; }


        public IList<BookAuthor> BookAuthors { get; private set; } = new List<BookAuthor>();

        public IList<BookLoan> BookLoans { get; private set; } = new List<BookLoan>();

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }
}
