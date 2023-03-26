namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Skilllist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        SkillValue = c.Int(nullable: false),
                        Cv_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.Cv_id)
                .Index(t => t.Cv_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Cv_id", "dbo.Cvs");
            DropIndex("dbo.Skills", new[] { "Cv_id" });
            DropTable("dbo.Skills");
        }
    }
}
