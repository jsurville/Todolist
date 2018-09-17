namespace Todolist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        DateFin = c.DateTime(),
                        Statut = c.Boolean(nullable: false),
                        Priorite = c.Int(),
                        CategorieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategorieID, cascadeDelete: true)
                .Index(t => t.CategorieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taches", "CategorieID", "dbo.Categories");
            DropIndex("dbo.Taches", new[] { "CategorieID" });
            DropTable("dbo.Taches");
            DropTable("dbo.Categories");
        }
    }
}
