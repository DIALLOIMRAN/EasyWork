namespace EasyWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naissance = c.DateTime(nullable: false),
                        photo = c.String(maxLength: 255, unicode: false),
                        cv = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 100, unicode: false),
                        prenom = c.String(maxLength: 100, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 100, unicode: false),
                        telephone = c.String(maxLength: 20, unicode: false),
                        adresse = c.String(maxLength: 255, unicode: false),
                        civilite = c.String(maxLength: 10, unicode: false),
                        RefVille = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ville", t => t.RefVille)
                .Index(t => t.RefVille);
            
            CreateTable(
                "dbo.Ville",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 100, unicode: false),
                        RefPays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pays", t => t.RefPays, cascadeDelete: true)
                .Index(t => t.RefPays);
            
            CreateTable(
                "dbo.Pays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recruteur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        poste = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 100, unicode: false),
                        prenom = c.String(maxLength: 100, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 100, unicode: false),
                        telephone = c.String(maxLength: 20, unicode: false),
                        adresse = c.String(maxLength: 255, unicode: false),
                        civilite = c.String(maxLength: 10, unicode: false),
                        RefVille = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ville", t => t.RefVille)
                .Index(t => t.RefVille);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidat", "RefVille", "dbo.Ville");
            DropForeignKey("dbo.Recruteur", "RefVille", "dbo.Ville");
            DropForeignKey("dbo.Ville", "RefPays", "dbo.Pays");
            DropIndex("dbo.Recruteur", new[] { "RefVille" });
            DropIndex("dbo.Ville", new[] { "RefPays" });
            DropIndex("dbo.Candidat", new[] { "RefVille" });
            DropTable("dbo.Recruteur");
            DropTable("dbo.Pays");
            DropTable("dbo.Ville");
            DropTable("dbo.Candidat");
        }
    }
}
