namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ändrish : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User_Education", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.User_Education", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.User_WorkExperience", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.User_Education", "Cv_id", c => c.Int());
            AddColumn("dbo.User_WorkExperience", "Cv_id", c => c.Int());
            CreateIndex("dbo.User_Education", "Cv_id");
            CreateIndex("dbo.User_WorkExperience", "Cv_id");
            AddForeignKey("dbo.User_Education", "Cv_id", "dbo.Cvs", "id");
            AddForeignKey("dbo.User_WorkExperience", "Cv_id", "dbo.Cvs", "id");
            DropColumn("dbo.User_Education", "ApplicationUser_Id");
            DropColumn("dbo.User_WorkExperience", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_WorkExperience", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.User_Education", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.User_WorkExperience", "Cv_id", "dbo.Cvs");
            DropForeignKey("dbo.User_Education", "Cv_id", "dbo.Cvs");
            DropIndex("dbo.User_WorkExperience", new[] { "Cv_id" });
            DropIndex("dbo.User_Education", new[] { "Cv_id" });
            DropColumn("dbo.User_WorkExperience", "Cv_id");
            DropColumn("dbo.User_Education", "Cv_id");
            CreateIndex("dbo.User_WorkExperience", "ApplicationUser_Id");
            CreateIndex("dbo.User_Education", "ApplicationUser_Id");
            AddForeignKey("dbo.User_WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.User_Education", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
