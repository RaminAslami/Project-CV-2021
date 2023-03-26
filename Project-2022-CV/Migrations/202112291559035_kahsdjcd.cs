namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kahsdjcd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MessageModels", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.MessageModels", "ReceiverId", c => c.String());
            AddColumn("dbo.MessageModels", "SenderId", c => c.String());
            DropColumn("dbo.MessageModels", "idUser");
            DropColumn("dbo.MessageModels", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MessageModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MessageModels", "idUser", c => c.String());
            DropColumn("dbo.MessageModels", "SenderId");
            DropColumn("dbo.MessageModels", "ReceiverId");
            CreateIndex("dbo.MessageModels", "ApplicationUser_Id");
            AddForeignKey("dbo.MessageModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
