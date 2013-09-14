namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Author : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.BlogAuthor",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        CanDeleteBlog = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.PostAuthor",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        CanDeletePost = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            AddColumn("dbo.Blogs", "AuthorId", c => c.Int());
            AddColumn("dbo.Posts", "AuthorId", c => c.Int());
            AddForeignKey("dbo.Blogs", "AuthorId", "dbo.BlogAuthor", "AuthorId");
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.PostAuthor", "AuthorId");
            CreateIndex("dbo.Blogs", "AuthorId");
            CreateIndex("dbo.Posts", "AuthorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PostAuthor", new[] { "AuthorId" });
            DropIndex("dbo.BlogAuthor", new[] { "AuthorId" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Blogs", new[] { "AuthorId" });
            DropForeignKey("dbo.PostAuthor", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BlogAuthor", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.PostAuthor");
            DropForeignKey("dbo.Blogs", "AuthorId", "dbo.BlogAuthor");
            DropColumn("dbo.Posts", "AuthorId");
            DropColumn("dbo.Blogs", "AuthorId");
            DropTable("dbo.PostAuthor");
            DropTable("dbo.BlogAuthor");
            DropTable("dbo.Authors");
        }
    }
}
