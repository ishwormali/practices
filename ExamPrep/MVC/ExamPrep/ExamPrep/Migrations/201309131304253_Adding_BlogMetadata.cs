namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_BlogMetadata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogMetadatas",
                c => new
                {
                    BlogId = c.Int(nullable: false, identity: false),
                    CreatedOn = c.DateTime(nullable: false),
                    LastUpdated = c.DateTime(nullable: false),
                    Language = c.String(),
                })
                .PrimaryKey(t => t.BlogId);
        }
        
        public override void Down()
        {
        }
    }
}
