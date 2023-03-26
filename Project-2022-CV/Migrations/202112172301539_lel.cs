namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "UserCreatorId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "UserCreatorId", c => c.Int(nullable: false));
        }
    }
}
