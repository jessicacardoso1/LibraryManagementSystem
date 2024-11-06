using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class Review : BaseEntity
    {
        public Book Book { get; set; }
        public int IdBook { get; set; }
    }
}
