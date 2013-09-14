using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}