using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChiquePiggyFidelimax.Models
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Caixa")]
        public int Caixa_Id { get; set; }
        [ForeignKey("Cliente")]
        public int Cliente_Id { get; set; }
        public Cliente Cliente { get; set; }
        public Caixa Caixa { get; set; }
        
        public int ResgatarPremio()
        {
            if (Caixa.Pontos >= 100)
            {
                return Caixa.Pontos - 100;
            }
                
            else
                return Caixa.Pontos;
        }
        
        public string AvisarCliente()
        {
            if (Caixa.Pontos >= 100)
                return Caixa.Pontos.ToString();

            return "Cliente possui saldo para resgate do Prêmio" + Caixa.Pontos;
        }
    }
}