namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtfishappening : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "ProjectImage", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ProjectImage", c => c.Binary());
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
        }
    }
}
