namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "UserCreatorId", c => c.Int(nullable: false));
            DropColumn("dbo.Images", "ImageData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageData", c => c.Binary());
            AlterColumn("dbo.Projects", "UserCreatorId", c => c.String());
        }
    }
}
