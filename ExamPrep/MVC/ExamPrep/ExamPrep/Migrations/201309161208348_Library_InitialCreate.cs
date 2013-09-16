namespace ExamPrep.Migrations.Library
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Library_InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 100),
                        LName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        UniqueId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        ISBN = c.String(nullable: false),
                        PublishedDate = c.DateTime(nullable: false),
                        Genre = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                        Publisher = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UniqueId)
                .ForeignKey("dbo.BookAuthors", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.Publisher, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Publisher);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookIssues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Member = c.Int(nullable: false),
                        Book_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_ID, cascadeDelete: true)
                .Index(t => t.Member)
                .Index(t => t.Book_ID);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        StartedDate = c.DateTime(nullable: false),
                        Expiration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AuthorIdentifier = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Members", new[] { "Id" });
            DropIndex("dbo.BookAuthors", new[] { "Id" });
            DropIndex("dbo.Memberships", new[] { "MemberId" });
            DropIndex("dbo.BookIssues", new[] { "Book_ID" });
            DropIndex("dbo.BookIssues", new[] { "Member" });
            DropIndex("dbo.Books", new[] { "Publisher" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropForeignKey("dbo.Members", "Id", "dbo.People");
            DropForeignKey("dbo.BookAuthors", "Id", "dbo.People");
            DropForeignKey("dbo.Memberships", "MemberId", "dbo.Members");
            DropForeignKey("dbo.BookIssues", "Book_ID", "dbo.Books");
            DropForeignKey("dbo.BookIssues", "Member", "dbo.Members");
            DropForeignKey("dbo.Books", "Publisher", "dbo.Publishers");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.BookAuthors");
            DropTable("dbo.Members");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Memberships");
            DropTable("dbo.BookIssues");
            DropTable("dbo.Publishers");
            DropTable("dbo.Books");
            DropTable("dbo.People");
        }
    }
}
