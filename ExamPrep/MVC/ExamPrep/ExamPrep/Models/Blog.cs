using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrep.Models
{
    
    public class Blog
    {
       [HiddenInput]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        [Required]
        [Column("Created_By_User")]
        public string CreatedBy { get; set; }


        public virtual BlogMetadata Metadata { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }

        
        public virtual BlogAuthor Author { get; set; }
    }
}