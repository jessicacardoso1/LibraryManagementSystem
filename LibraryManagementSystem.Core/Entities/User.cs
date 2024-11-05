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
        public User(string name, string email) : base()
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public IList<BookAuthor> BookAuthors { get; private set; } = new List<BookAuthor>();

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }
}
