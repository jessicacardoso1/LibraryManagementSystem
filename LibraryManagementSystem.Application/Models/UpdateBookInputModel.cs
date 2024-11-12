using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class UpdateBookInputModel
    {
        public int IdBook { get; set; }
        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
    }
}
