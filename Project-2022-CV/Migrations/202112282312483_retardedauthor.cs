namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retardedauthor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "GitUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "GitUserName", c => c.String());
        }
    }
}
