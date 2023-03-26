namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdderadeImageklassen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageData");
        }
    }
}
