namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authoremail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageModels", "AuthorEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessageModels", "AuthorEmail");
        }
    }
}
