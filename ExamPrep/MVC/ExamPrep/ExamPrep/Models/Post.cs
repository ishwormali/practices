using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
    }
}