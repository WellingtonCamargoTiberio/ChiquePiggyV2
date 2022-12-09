using System.Data.Entity;
using ChiquePiggyFidelimax.Models;


namespace ChiquePiggyFidelimax.Context
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=DefaultConnection")
        {

        }       
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }    
        public DbSet<Caixa> Caixa { get; set; }
    }
}