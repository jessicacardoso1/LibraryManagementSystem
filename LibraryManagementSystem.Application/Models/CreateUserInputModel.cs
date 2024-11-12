using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class CreateUserInputModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; set; }

        public User ToEntity()
            => new(Name, Email, BirthDate);
    }
}
