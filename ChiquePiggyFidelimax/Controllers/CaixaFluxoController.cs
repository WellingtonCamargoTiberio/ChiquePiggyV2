using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChiquePiggyFidelimax.Context;
using ChiquePiggyFidelimax.Models;
using Microsoft.Web.Mvc;

namespace ChiquePiggyFidelimax.Controllers
{
    public class CaixaFluxoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CaixaFluxo
        public ActionResult Index()
        {
            return View(db.Caixa.ToList());
        }

        // GET: CaixaFluxo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caixa caixa = db.Caixa.Find(id);
            if (caixa == null)
            {
                return HttpNotFound();
            }
            return View(caixa);
        }

        // GET: CaixaFluxo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaixaFluxo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Caixa caixa)
        {
          
            if (ClienteExiste(caixa.Cpf))
            {
                if (ModelState.IsValid)
                {
                    caixa.DobrarPontos(caixa.DataCompra);
                    caixa.TrocaValorPorPontos(caixa.ValorTotalCompra);
                    db.Caixa.Add(caixa);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
                return RedirectToAction("Create", "Cliente");
          
            return View(caixa);
        }

        // GET: CaixaFluxo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caixa caixa = db.Caixa.Find(id);
            if (caixa == null)
            {
                return HttpNotFound();
            }
            return View(caixa);
        }

        // POST: CaixaFluxo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Caixa caixa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caixa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caixa);
        }

        // GET: CaixaFluxo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caixa caixa = db.Caixa.Find(id);
            if (caixa == null)
            {
                return HttpNotFound();
            }
            return View(caixa);
        }

        // POST: CaixaFluxo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caixa caixa = db.Caixa.Find(id);
            db.Caixa.Remove(caixa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AjaxOnly]
        public JsonResult VerificarClienteCadastrado(Caixa pModel)
        {
            return Json(new { clienteExistente = ClienteExiste(pModel.Cpf) },JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool ClienteExiste(string cpf)
        {
            return db.Clientes.Any(c => c.Cpf== cpf);
        }
    }
}
