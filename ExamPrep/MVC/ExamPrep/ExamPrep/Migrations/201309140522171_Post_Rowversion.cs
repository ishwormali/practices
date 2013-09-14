namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post_Rowversion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "RowVersion");
        }
    }
}
