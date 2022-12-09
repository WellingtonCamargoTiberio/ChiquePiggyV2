namespace ChiquePiggyFidelimax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exclusaoPropriedades : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transacaos", "ValorTotalCompra");
            DropColumn("dbo.Transacaos", "TotalPontos");
            DropColumn("dbo.Transacaos", "DataTransacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transacaos", "DataTransacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transacaos", "TotalPontos", c => c.Int(nullable: false));
            AddColumn("dbo.Transacaos", "ValorTotalCompra", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
