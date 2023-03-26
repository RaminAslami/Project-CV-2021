namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagewtf2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserProjects", newName: "ProjectApplicationUsers");
            DropPrimaryKey("dbo.ProjectApplicationUsers");
            CreateTable(
                "dbo.MessageModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 600),
                        WhenSent = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        ReadMessage = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddPrimaryKey("dbo.ProjectApplicationUsers", new[] { "Project_Id", "ApplicationUser_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MessageModels", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.ProjectApplicationUsers");
            DropTable("dbo.MessageModels");
            AddPrimaryKey("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id", "Project_Id" });
            RenameTable(name: "dbo.ProjectApplicationUsers", newName: "ApplicationUserProjects");
        }
    }
}
