namespace ChiquePiggyFidelimax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Caixas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Caixas", "Transacao_Id", "dbo.Transacaos");
            DropIndex("dbo.Caixas", new[] { "Cliente_Id" });
            DropIndex("dbo.Caixas", new[] { "Transacao_Id" });
            DropIndex("dbo.Transacaos", new[] { "Cliente_Id" });
            AddColumn("dbo.Caixas", "Cpf", c => c.String());
            AddColumn("dbo.Caixas", "ValorTotalCompra", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Caixas", "DataCompra", c => c.DateTime(nullable: false));
            AddColumn("dbo.Caixas", "Pontos", c => c.Int(nullable: false));
            AddColumn("dbo.Transacaos", "TotalPontos", c => c.Int(nullable: false));
            DropColumn("dbo.Caixas", "Cliente_Id");
            DropColumn("dbo.Caixas", "Transacao_Id");
            DropColumn("dbo.Transacaos", "Pontos");
            DropColumn("dbo.Transacaos", "Cliente_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transacaos", "Cliente_Id", c => c.Int());
            AddColumn("dbo.Transacaos", "Pontos", c => c.Int(nullable: false));
            AddColumn("dbo.Caixas", "Transacao_Id", c => c.Int());
            AddColumn("dbo.Caixas", "Cliente_Id", c => c.Int());
            DropColumn("dbo.Transacaos", "TotalPontos");
            DropColumn("dbo.Caixas", "Pontos");
            DropColumn("dbo.Caixas", "DataCompra");
            DropColumn("dbo.Caixas", "ValorTotalCompra");
            DropColumn("dbo.Caixas", "Cpf");
            CreateIndex("dbo.Transacaos", "Cliente_Id");
            CreateIndex("dbo.Caixas", "Transacao_Id");
            CreateIndex("dbo.Caixas", "Cliente_Id");
            AddForeignKey("dbo.Caixas", "Transacao_Id", "dbo.Transacaos", "Id");
            AddForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Caixas", "Cliente_Id", "dbo.Clientes", "Id");
        }
    }
}
