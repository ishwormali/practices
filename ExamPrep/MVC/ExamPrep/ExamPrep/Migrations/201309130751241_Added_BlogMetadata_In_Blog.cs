namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_BlogMetadata_In_Blog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Metadata_BlogId", c => c.Int());
            AddForeignKey("dbo.Blogs", "Metadata_BlogId", "dbo.BlogMetadatas", "BlogId");
            CreateIndex("dbo.Blogs", "Metadata_BlogId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Blogs", new[] { "Metadata_BlogId" });
            DropForeignKey("dbo.Blogs", "Metadata_BlogId", "dbo.BlogMetadatas");
            DropColumn("dbo.Blogs", "Metadata_BlogId");
        }
    }
}
