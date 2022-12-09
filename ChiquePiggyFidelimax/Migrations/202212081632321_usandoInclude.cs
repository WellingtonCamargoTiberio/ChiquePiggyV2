namespace ChiquePiggyFidelimax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usandoInclude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transacaos", "Caixa_Id", c => c.Int());
            AddColumn("dbo.Transacaos", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.Transacaos", "Caixa_Id");
            CreateIndex("dbo.Transacaos", "Cliente_Id");
            AddForeignKey("dbo.Transacaos", "Caixa_Id", "dbo.Caixas", "Id");
            AddForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Transacaos", "Caixa_Id", "dbo.Caixas");
            DropIndex("dbo.Transacaos", new[] { "Cliente_Id" });
            DropIndex("dbo.Transacaos", new[] { "Caixa_Id" });
            DropColumn("dbo.Transacaos", "Cliente_Id");
            DropColumn("dbo.Transacaos", "Caixa_Id");
        }
    }
}
