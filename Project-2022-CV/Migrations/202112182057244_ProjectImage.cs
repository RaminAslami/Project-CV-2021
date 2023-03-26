namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectImage_Id", c => c.Int());
            CreateIndex("dbo.Projects", "ProjectImage_Id");
            AddForeignKey("dbo.Projects", "ProjectImage_Id", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectImage_Id", "dbo.Images");
            DropIndex("dbo.Projects", new[] { "ProjectImage_Id" });
            DropColumn("dbo.Projects", "ProjectImage_Id");
        }
    }
}
