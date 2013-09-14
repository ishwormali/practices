using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    [Table("BlogAuthor")]
    public class BlogAuthor:Author
    {
        public virtual ICollection<Blog> Blogs { get; set; }
        public bool CanAuthorDeleteBlog { get; set; }

    }
}