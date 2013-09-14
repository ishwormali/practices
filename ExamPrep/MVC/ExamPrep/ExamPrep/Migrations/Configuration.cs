namespace ExamPrep.Migrations
{
    using ExamPrep.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExamPrep.Models.DB.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamPrep.Models.DB.BlogDbContext context)
        {
            //context.Blogs.AddOrUpdate(new Blog() { Title = "New Blog created on " + DateTime.Now.ToString(), CreatedBy = "ishwor" });
            var blogAuthors = new List<BlogAuthor>(){new BlogAuthor(){FirstName="BlogAuthor1",LastName="BlogAuthor1LastName2"},
                new BlogAuthor(){FirstName="BlogAuthor2",LastName="BlogAuthor1LastName2"}};
            context.BlogAuthors.AddOrUpdate(blogAuthors.ToArray());

            var postAuthors = new List<PostAuthor>(){new PostAuthor(){FirstName="PostAuthor1",LastName="PostAuthor1LastName1"},
                new PostAuthor(){FirstName="PostAuthor2",LastName="PostAuthor1LastName2"}};
            context.PostAuthors.AddOrUpdate(postAuthors.ToArray());

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
