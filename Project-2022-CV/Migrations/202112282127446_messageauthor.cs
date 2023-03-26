namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageauthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageModels", "Author", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.MessageModels", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MessageModels", "Title", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.MessageModels", "Author");
        }
    }
}
