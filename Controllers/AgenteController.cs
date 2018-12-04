using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguros.Models;

namespace Seguros.Controllers
{
    public class AgenteController : Controller
    {
        private SegurosEntities db = new SegurosEntities();

        //
        // GET: /Agente/

        public ActionResult Index()
        {
            var agente = db.Agente.Include(a => a.Aseguradora);
            return View(agente.ToList());
        }

        //
        // GET: /Agente/Details/5

        public ActionResult Details(int id = 0)
        {
            Agente agente = db.Agente.Find(id);
            if (agente == null)
            {
                return HttpNotFound();
            }
            return View(agente);
        }

        //
        // GET: /Agente/Create

        public ActionResult Create()
        {
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora");
            return View();
        }

        //
        // POST: /Agente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Agente agente)
        {
            if (ModelState.IsValid)
            {
                db.Agente.Add(agente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", agente.IdAseguradora);
            return View(agente);
        }

        //
        // GET: /Agente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Agente agente = db.Agente.Find(id);
            if (agente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", agente.IdAseguradora);
            return View(agente);
        }

        //
        // POST: /Agente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agente agente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", agente.IdAseguradora);
            return View(agente);
        }

        //
        // GET: /Agente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Agente agente = db.Agente.Find(id);
            if (agente == null)
            {
                return HttpNotFound();
            }
            return View(agente);
        }

        //
        // POST: /Agente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agente agente = db.Agente.Find(id);
            db.Agente.Remove(agente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}