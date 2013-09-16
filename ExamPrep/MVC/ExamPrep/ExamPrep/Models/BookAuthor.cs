using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class BookAuthor:Person
    {
        public ICollection<Book> Books { get; set; }
        public string AuthorIdentifier { get; set; }
    }
}