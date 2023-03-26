namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagemodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectApplicationUsers", newName: "ApplicationUserProjects");
            DropPrimaryKey("dbo.ApplicationUserProjects");
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "ApplicationUser_Id", "Project_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationUserProjects");
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "Project_Id", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserProjects", newName: "ProjectApplicationUsers");
        }
    }
}
