using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class BookIssue
    {
        public int Id { get; set; }
        public DateTime IssuedDate { get; set; }

        public DateTime ReturnDate { get; set; }

       
        public Member Member { get; set; }

       
        public Book Book { get; set; }


    }
}