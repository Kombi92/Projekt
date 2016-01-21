namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lekcjas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Typ = c.String(),
                        IloscGodzin = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Uczens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        DataZapisu = c.DateTime(nullable: false),
                        Stopien = c.String(),
                        Preferencje = c.String(),
                        Lekcja_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uczens");
            DropTable("dbo.Lekcjas");
        }
    }
}
