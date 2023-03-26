namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hdhghqa : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserProjects", newName: "ProjectApplicationUsers");
            DropPrimaryKey("dbo.ProjectApplicationUsers");
            AddColumn("dbo.MessageModels", "ReceiverId_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MessageModels", "SenderId_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.ProjectApplicationUsers", new[] { "Project_Id", "ApplicationUser_Id" });
            CreateIndex("dbo.MessageModels", "ReceiverId_Id");
            CreateIndex("dbo.MessageModels", "SenderId_Id");
            AddForeignKey("dbo.MessageModels", "ReceiverId_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MessageModels", "SenderId_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.MessageModels", "ReceiverId");
            DropColumn("dbo.MessageModels", "SenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MessageModels", "SenderId", c => c.String());
            AddColumn("dbo.MessageModels", "ReceiverId", c => c.String());
            DropForeignKey("dbo.MessageModels", "SenderId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageModels", "ReceiverId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MessageModels", new[] { "SenderId_Id" });
            DropIndex("dbo.MessageModels", new[] { "ReceiverId_Id" });
            DropPrimaryKey("dbo.ProjectApplicationUsers");
            DropColumn("dbo.MessageModels", "SenderId_Id");
            DropColumn("dbo.MessageModels", "ReceiverId_Id");
            AddPrimaryKey("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id", "Project_Id" });
            RenameTable(name: "dbo.ProjectApplicationUsers", newName: "ApplicationUserProjects");
        }
    }
}
