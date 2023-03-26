namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MessageModels", "idUser", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MessageModels", "idUser", c => c.String(nullable: false));
        }
    }
}
