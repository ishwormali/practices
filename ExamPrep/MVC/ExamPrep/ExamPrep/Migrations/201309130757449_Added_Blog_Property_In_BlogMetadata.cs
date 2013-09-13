namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Blog_Property_In_BlogMetadata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "Metadata_BlogId", "dbo.BlogMetadatas");
            DropIndex("dbo.Blogs", new[] { "Metadata_BlogId" });
            AlterColumn("dbo.BlogMetadatas", "BlogId", c => c.Int(nullable: false));
            AddForeignKey("dbo.BlogMetadatas", "BlogId", "dbo.Blogs", "Id");
            CreateIndex("dbo.BlogMetadatas", "BlogId");
            DropColumn("dbo.Blogs", "Metadata_BlogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Metadata_BlogId", c => c.Int());
            DropIndex("dbo.BlogMetadatas", new[] { "BlogId" });
            DropForeignKey("dbo.BlogMetadatas", "BlogId", "dbo.Blogs");
            AlterColumn("dbo.BlogMetadatas", "BlogId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Blogs", "Metadata_BlogId");
            AddForeignKey("dbo.Blogs", "Metadata_BlogId", "dbo.BlogMetadatas", "BlogId");
        }
    }
}
