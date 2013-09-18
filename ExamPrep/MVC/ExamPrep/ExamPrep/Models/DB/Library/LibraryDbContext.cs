using ExamPrep.Models.DB.Library.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamPrep.Models.DB.Library
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<BookAuthor> Authors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookIssue> BookIssuances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasKey(m => m.UniqueId).Property(m=>m.Genre).IsRequired();
            //modelBuilder.Entity<Book>().Property(m => m.ISBN).IsRequired();
            //modelBuilder.Entity<Book>().Property(m => m.PublishedDate).IsRequired();
            //modelBuilder.Entity<Book>().HasRequired(m => m.Author).WithMany(m=>m.Books).Map(m=>m.MapKey("Author_Id"));
            //modelBuilder.Entity<Book>().HasRequired(m => m.Publisher).WithMany(m=>m.Books).Map(m=>m.MapKey("Publisher"));

            modelBuilder.Entity<Person>().Property(m => m.FirstName).IsRequired().HasColumnName("FName").HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(m => m.LastName).IsRequired().HasColumnName("LName").HasMaxLength(100);
            modelBuilder.Entity<Person>().Ignore(m => m.FullName);

            modelBuilder.Entity<BookAuthor>().Map(m => m.ToTable("BookAuthors")).Property(m => m.AuthorIdentifier).IsRequired().HasMaxLength(500);

            modelBuilder.Entity<Membership>().HasKey(m=>m.MemberId).Property(m=>m.MemberId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            modelBuilder.Entity<Member>().Map(m=>m.ToTable("Members")).HasRequired(m=>m.Membership).WithRequiredPrincipal().WillCascadeOnDelete();


            modelBuilder.Entity<Publisher>().Property(m => m.Name).IsRequired();

            modelBuilder.Entity<BookIssue>().HasRequired(m=>m.Book).WithMany().Map(m=>m.MapKey("Book_ID"));
            modelBuilder.Entity<BookIssue>().HasRequired(m => m.Member).WithMany(m=>m.AllIssuances).Map(m => m.MapKey("Member"));
            modelBuilder.Configurations.Add(new BookMap());

            base.OnModelCreating(modelBuilder);
            
        }
    }
}