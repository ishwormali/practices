namespace ExamPrep.Migrations.Library
{
    using ExamPrep.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class LibraryConfiguration : DbMigrationsConfiguration<ExamPrep.Models.DB.Library.LibraryDbContext>
    {
        public LibraryConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamPrep.Models.DB.Library.LibraryDbContext context)
        {
            context.Authors.Add(new BookAuthor() { FirstName = "Mathew", LastName = "Reily", AuthorIdentifier = "0000001" });
            context.Authors.Add(new BookAuthor() { FirstName = "Jane", LastName = "Austen", AuthorIdentifier = "0000002" });

            context.Members.Add(new Member() { FullName = "Ishwor Mali", DateOfBirth = new DateTime(1984, 1, 1), Membership = new Membership() { Expiration = new DateTime(2014, 1, 1), StartedDate = new DateTime(2012, 1, 1) } });
            

            base.Seed(context);
        }
    }
}
