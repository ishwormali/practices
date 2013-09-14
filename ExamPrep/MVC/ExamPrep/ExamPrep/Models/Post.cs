using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }


        public virtual PostAuthor Author { get; set; }
    }
}