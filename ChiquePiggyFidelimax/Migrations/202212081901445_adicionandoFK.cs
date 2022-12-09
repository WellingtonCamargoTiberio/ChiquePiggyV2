namespace ChiquePiggyFidelimax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionandoFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transacaos", "Caixa_Id", "dbo.Caixas");
            DropForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Transacaos", new[] { "Caixa_Id" });
            DropIndex("dbo.Transacaos", new[] { "Cliente_Id" });
            AlterColumn("dbo.Transacaos", "Caixa_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Transacaos", "Cliente_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Transacaos", "Caixa_Id");
            CreateIndex("dbo.Transacaos", "Cliente_Id");
            AddForeignKey("dbo.Transacaos", "Caixa_Id", "dbo.Caixas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Transacaos", "Caixa_Id", "dbo.Caixas");
            DropIndex("dbo.Transacaos", new[] { "Cliente_Id" });
            DropIndex("dbo.Transacaos", new[] { "Caixa_Id" });
            AlterColumn("dbo.Transacaos", "Cliente_Id", c => c.Int());
            AlterColumn("dbo.Transacaos", "Caixa_Id", c => c.Int());
            CreateIndex("dbo.Transacaos", "Cliente_Id");
            CreateIndex("dbo.Transacaos", "Caixa_Id");
            AddForeignKey("dbo.Transacaos", "Cliente_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Transacaos", "Caixa_Id", "dbo.Caixas", "Id");
        }
    }
}
