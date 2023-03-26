namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gitusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GitUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GitUserName");
        }
    }
}
