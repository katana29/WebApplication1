namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class predmet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predmet",
                c => new
                    {
                        PredmetID = c.String(nullable: false, maxLength: 128),
                        NazivPredmeta = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PredmetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Predmet");
        }
    }
}
