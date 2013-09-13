namespace ExamPrep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogCreatedBy_ColumnNameChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Blogs", name: "CreatedBy", newName: "Created_By_User");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Blogs", name: "Created_By_User", newName: "CreatedBy");
        }
    }
}
