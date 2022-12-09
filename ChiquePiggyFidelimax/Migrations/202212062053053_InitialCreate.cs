namespace ChiquePiggyFidelimax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorTotalCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pontos = c.Int(nullable: false),
                        DataTransacao = c.DateTime(nullable: false),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Transacaos", new[] { "Cliente_Id" });
            DropTable("dbo.Transacaos");
            DropTable("dbo.Clientes");
        }
    }
}
