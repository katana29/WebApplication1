namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class polaganje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polaganje", "PredmetID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Polaganje", "PredmetID");
            AddForeignKey("dbo.Polaganje", "PredmetID", "dbo.Predmet", "PredmetID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Polaganje", "PredmetID", "dbo.Predmet");
            DropIndex("dbo.Polaganje", new[] { "PredmetID" });
            DropColumn("dbo.Polaganje", "PredmetID");
        }
    }
}
