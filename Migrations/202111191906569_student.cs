namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        BrIndexa = c.String(maxLength: 100),
                        imePrezime = c.String(maxLength: 100),
                        grad = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
        }
    }
}
