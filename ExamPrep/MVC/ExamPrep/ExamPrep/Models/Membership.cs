using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Membership
    {
        public int MemberId { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime Expiration { get; set; }
        //public Member Member { get; set; }
    }
}