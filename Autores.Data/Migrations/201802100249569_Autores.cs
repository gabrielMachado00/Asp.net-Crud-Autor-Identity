namespace Autores.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Autores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        IdLivro = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Titulo = c.String(),
                        Genero = c.String(),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLivro)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        CPF = c.String(),
                        Email = c.String(nullable: false, maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Livro", new[] { "Id" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Livro");
        }
    }
}
