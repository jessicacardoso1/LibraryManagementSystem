﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class BookAuthor : BaseEntity
    {
        public BookAuthor(int idBook, Book book, int idAuthor, User author) : base()
        {
            IdBook = idBook;
            Book = book;
            IdAuthor = idAuthor;
            Author = author;
        }

        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public int IdAuthor { get; private set; }
        public User Author { get; private set; }
    }
}
