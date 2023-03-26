namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileImage_Id", "dbo.Images");
            DropForeignKey("dbo.Projects", "ProjectImage_Id", "dbo.Images");
            DropIndex("dbo.Projects", new[] { "ProjectImage_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfileImage_Id" });
            AddColumn("dbo.Projects", "ProjectImage", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.Binary());
            DropColumn("dbo.Projects", "ProjectImage_Id");
            DropColumn("dbo.AspNetUsers", "ProfileImage_Id");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "ProfileImage_Id", c => c.Int());
            AddColumn("dbo.Projects", "ProjectImage_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "ProfileImage");
            DropColumn("dbo.Projects", "ProjectImage");
            CreateIndex("dbo.AspNetUsers", "ProfileImage_Id");
            CreateIndex("dbo.Projects", "ProjectImage_Id");
            AddForeignKey("dbo.Projects", "ProjectImage_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.AspNetUsers", "ProfileImage_Id", "dbo.Images", "Id");
        }
    }
}
