using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Book
    {
        
        public int UniqueId { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }

        public bool HasBeenPublished { get { return PublishedDate != DateTime.MinValue && PublishedDate != DateTime.MaxValue; } }

        public Genre Genre { get; set; }

        public BookAuthor Author { get; set; }

        public Publisher Publisher { get; set; }
    }
}