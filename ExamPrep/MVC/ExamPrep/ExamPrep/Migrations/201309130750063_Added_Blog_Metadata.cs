namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Blog_Metadata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogMetadatas",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogMetadatas");
        }
    }
}
