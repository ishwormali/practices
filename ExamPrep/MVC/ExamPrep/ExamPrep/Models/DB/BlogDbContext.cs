using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using EFTracingProvider;

namespace ExamPrep.Models.DB
{
    public class BlogDbContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogMetadata> BlogMetadatas { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogAuthor> BlogAuthors { get; set; }
        public DbSet<PostAuthor> PostAuthors { get; set; }
        public BlogDbContext()
        {
            
            //((IObjectContextAdapter)this).ObjectContext.EnableTracing();
        }

        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }

    }
}