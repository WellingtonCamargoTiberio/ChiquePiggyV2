using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using ChiquePiggy.Domain;
using ChiquePiggy.Helpers.Actions;
using ChiquePiggy.Helpers.Views;
using ChiquePiggy.Services;
using ChiquePiggyFidelimax.Context;
using ChiquePiggyFidelimax.Models;

namespace ChiquePiggyFidelimax.Controllers
{
    public class CaixaController : Controller
    {
        private CaixaService _caixaService;
        private Contexto db = new Contexto();

        public CaixaController()
        {
            _caixaService = new CaixaService();
        }

        public ActionResult Inicio()
        {
            var response = _caixaService.SelecionarDadosUsuario();
            return View(CaixaViews.Inicio);
        }

        public ActionResult PontuacaoConsumidor(PontuacaoCaixaRequest request)
        {
            var response = _caixaService.PontuarConsumidor(request);
            return View(CaixaViews.Pontuacao);
        }

        public ActionResult PontuacaoConsumidorv2(PontuacaoCaixaRequest request)
        {
            var response = _caixaService.PontuarConsumidor(request);
            return View(CaixaViews.Pontuacao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cpf,ValorTotalCompra")] Caixa caixa, string cpf)
        {
            Cliente cliente = new Cliente();
            
            if (!cliente.ClienteExiste(cpf))
            {
                if (ModelState.IsValid)
                {
                    db.Caixa.Add(caixa);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
                return RedirectToAction("Create");

                return View(cliente);  
            
        }
    }
}