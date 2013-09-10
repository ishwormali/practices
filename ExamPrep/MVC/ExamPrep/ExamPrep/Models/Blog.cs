using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{

    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DbSet<Post> Posts { get; set; }
        
    }
}