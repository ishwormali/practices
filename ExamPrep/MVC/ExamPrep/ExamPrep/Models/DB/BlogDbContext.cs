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

        public BlogDbContext()
        {
            //((IObjectContextAdapter)this).ObjectContext.EnableTracing();
        }
    }
}