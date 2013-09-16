using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{

    public class Member:Person
    {
        
        public DateTime DateOfBirth{ get; set; }
        
        public ICollection<BookIssue> AllIssuances { get; set; }

        public Membership Membership { get; set; }

    }
}