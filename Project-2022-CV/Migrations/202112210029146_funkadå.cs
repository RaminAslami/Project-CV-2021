namespace Project_2022_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class funkadå : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CurrentUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CurrentUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phonenumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Private = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
