using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}