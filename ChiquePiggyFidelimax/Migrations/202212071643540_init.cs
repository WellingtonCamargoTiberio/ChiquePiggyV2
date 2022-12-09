namespace ChiquePiggyFidelimax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caixas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cliente_Id = c.Int(),
                        Transacao_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Transacaos", t => t.Transacao_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Transacao_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caixas", "Transacao_Id", "dbo.Transacaos");
            DropForeignKey("dbo.Caixas", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Caixas", new[] { "Transacao_Id" });
            DropIndex("dbo.Caixas", new[] { "Cliente_Id" });
            DropTable("dbo.Caixas");
        }
    }
}
