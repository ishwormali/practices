using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    
    public class Blog
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        
        public string CreatedBy { get; set; }
    }
}