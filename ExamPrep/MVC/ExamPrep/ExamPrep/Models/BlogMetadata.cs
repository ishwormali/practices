using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class BlogMetadata
    {
        [Key]
        
        [ForeignKey("Blog")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlogId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Language { get; set; }

        public virtual Blog Blog { get; set; }
    }
}