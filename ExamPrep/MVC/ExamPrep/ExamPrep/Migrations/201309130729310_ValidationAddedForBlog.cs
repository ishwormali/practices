namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationAddedForBlog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Blogs", "CreatedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "CreatedBy", c => c.String());
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false));
        }
    }
}
