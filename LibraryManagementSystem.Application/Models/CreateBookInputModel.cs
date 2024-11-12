using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class CreateBookInputModel
    {
        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }

        public Book ToEntity()
            => new(Title, ISBN, PublicationYear);
    }
}
