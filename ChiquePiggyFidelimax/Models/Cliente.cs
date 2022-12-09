using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ChiquePiggyFidelimax.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }


        public bool ClienteExiste(string cpf)
        {
            Cliente cliente = new Cliente();    
            return cliente.Cpf == cpf;            
        }

    }
}