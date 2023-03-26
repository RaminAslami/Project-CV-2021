namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class messagewtf : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectApplicationUsers", newName: "ApplicationUserProjects");
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.ApplicationUserProjects");
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "ApplicationUser_Id", "Project_Id" });

        }

        public override void Down()
        {
            CreateTable(
                "dbo.Messages",
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
                .PrimaryKey(t => t.Id);

            DropPrimaryKey("dbo.ApplicationUserProjects");
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "Project_Id", "ApplicationUser_Id" });
            CreateIndex("dbo.Messages", "ApplicationUser_Id");
            AddForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            RenameTable(name: "dbo.ApplicationUserProjects", newName: "ProjectApplicationUsers");
        }
    }
}
