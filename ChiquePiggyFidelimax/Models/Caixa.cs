using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChiquePiggyFidelimax.Models
{

    public class Caixa
    {
        [Key]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public decimal ValorTotalCompra { get; set; }
        public DateTime DataCompra { get; set; } = DateTime.Now;
        public int Pontos { get; set; }

        public void TrocaValorPorPontos(decimal valorTotalCompra)
        {
            if (valorTotalCompra > 0)
                Pontos = (int)Math.Ceiling(valorTotalCompra);
        }
        public int DobrarPontos(DateTime diaSemana)
        {
            switch (diaSemana.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Pontos = (int)Math.Ceiling(ValorTotalCompra) * 2;
                    return Pontos;
                case DayOfWeek.Tuesday:
                    Pontos = (int)Math.Ceiling(ValorTotalCompra) * 2;
                    return Pontos;
                default:
                    Pontos = (int)Math.Ceiling(ValorTotalCompra);
                    return Pontos;

            }
        }
    }
}