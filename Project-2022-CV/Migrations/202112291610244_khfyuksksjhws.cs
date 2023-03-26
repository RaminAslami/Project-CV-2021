namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class khfyuksksjhws : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectApplicationUsers", newName: "ApplicationUserProjects");
            DropForeignKey("dbo.MessageModels", "ReceiverId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageModels", "SenderId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MessageModels", new[] { "ReceiverId_Id" });
            DropIndex("dbo.MessageModels", new[] { "SenderId_Id" });
            DropPrimaryKey("dbo.ApplicationUserProjects");
            AddColumn("dbo.MessageModels", "ReceiverId", c => c.String());
            AddColumn("dbo.MessageModels", "SenderId", c => c.String());
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "ApplicationUser_Id", "Project_Id" });
            DropColumn("dbo.MessageModels", "ReceiverId_Id");
            DropColumn("dbo.MessageModels", "SenderId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MessageModels", "SenderId_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MessageModels", "ReceiverId_Id", c => c.String(maxLength: 128));
            DropPrimaryKey("dbo.ApplicationUserProjects");
            DropColumn("dbo.MessageModels", "SenderId");
            DropColumn("dbo.MessageModels", "ReceiverId");
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "Project_Id", "ApplicationUser_Id" });
            CreateIndex("dbo.MessageModels", "SenderId_Id");
            CreateIndex("dbo.MessageModels", "ReceiverId_Id");
            AddForeignKey("dbo.MessageModels", "SenderId_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MessageModels", "ReceiverId_Id", "dbo.AspNetUsers", "Id");
            RenameTable(name: "dbo.ApplicationUserProjects", newName: "ProjectApplicationUsers");
        }
    }
}
