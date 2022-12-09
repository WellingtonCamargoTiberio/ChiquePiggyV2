using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Domain
{
    public class PontuacaoCaixaRequest
    {

        public string CPF { get; set; }

        public decimal Pontuacao { get; set; }

        public bool ValidarEntradasParametros() => !String.IsNullOrEmpty(CPF) && Pontuacao > 0;
    }
}
