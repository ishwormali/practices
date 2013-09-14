namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Author1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogAuthor", "CanAuthorDeleteBlog", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostAuthor", "CanAuthorDeletePost", c => c.Boolean(nullable: false));
            DropColumn("dbo.BlogAuthor", "CanDeleteBlog");
            DropColumn("dbo.PostAuthor", "CanDeletePost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostAuthor", "CanDeletePost", c => c.Boolean(nullable: false));
            AddColumn("dbo.BlogAuthor", "CanDeleteBlog", c => c.Boolean(nullable: false));
            DropColumn("dbo.PostAuthor", "CanAuthorDeletePost");
            DropColumn("dbo.BlogAuthor", "CanAuthorDeleteBlog");
        }
    }
}
