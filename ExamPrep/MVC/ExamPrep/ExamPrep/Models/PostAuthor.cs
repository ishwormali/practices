using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    [Table("PostAuthor")]
    public class PostAuthor : Author
    {
        public virtual ICollection<Post> Posts { get; set; }
        public bool CanAuthorDeletePost { get; set; }
    }
}