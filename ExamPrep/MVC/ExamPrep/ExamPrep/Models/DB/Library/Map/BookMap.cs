using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ExamPrep.Models.DB.Library.Map
{
    public class BookMap:EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            this.HasKey(m => m.UniqueId).Property(m => m.Genre).IsRequired();
            this.Property(m => m.ISBN).IsRequired();
            this.Property(m => m.PublishedDate).IsRequired();
            this.HasRequired(m => m.Author).WithMany(m => m.Books).Map(m => m.MapKey("Author_Id"));
            this.HasRequired(m => m.Publisher).WithMany(m => m.Books).Map(m => m.MapKey("Publisher"));

        }
    }
}