namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NowyUczen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Uczens", "Lekcja_ID", c => c.Int());
            CreateIndex("dbo.Uczens", "Lekcja_ID");
            AddForeignKey("dbo.Uczens", "Lekcja_ID", "dbo.Lekcjas", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uczens", "Lekcja_ID", "dbo.Lekcjas");
            DropIndex("dbo.Uczens", new[] { "Lekcja_ID" });
            AlterColumn("dbo.Uczens", "Lekcja_ID", c => c.Int(nullable: false));
        }
    }
}
