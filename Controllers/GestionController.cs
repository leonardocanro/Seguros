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
    public class GestionController : Controller
    {
        private SegurosEntities db = new SegurosEntities();

        //
        // GET: /Gestion/

        public ActionResult Index()
        {
            var gestionfalabella = db.GestionFalabella.Include(g => g.Agente).Include(g => g.Aseguradora);
            return View(gestionfalabella.ToList());
        }

        //
        // GET: /Gestion/Details/5

        public ActionResult Details(int id = 0)
        {
            GestionFalabella gestionfalabella = db.GestionFalabella.Find(id);
            if (gestionfalabella == null)
            {
                return HttpNotFound();
            }
            return View(gestionfalabella);
        }

        //
        // GET: /Gestion/Create

        public ActionResult Create()
        {
            ViewBag.IdAgente = new SelectList(db.Agente, "IdAgente", "NombreAgente");
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora");
            return View();
        }

        //
        // POST: /Gestion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GestionFalabella gestionfalabella)
        {
            if (ModelState.IsValid)
            {
                db.GestionFalabella.Add(gestionfalabella);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgente = new SelectList(db.Agente, "IdAgente", "NombreAgente", gestionfalabella.IdAgente);
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", gestionfalabella.IdAseguradora);
            return View(gestionfalabella);
        }

        //
        // GET: /Gestion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GestionFalabella gestionfalabella = db.GestionFalabella.Find(id);
            if (gestionfalabella == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAgente = new SelectList(db.Agente, "IdAgente", "NombreAgente", gestionfalabella.IdAgente);
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", gestionfalabella.IdAseguradora);
            return View(gestionfalabella);
        }

        //
        // POST: /Gestion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GestionFalabella gestionfalabella)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestionfalabella).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgente = new SelectList(db.Agente, "IdAgente", "NombreAgente", gestionfalabella.IdAgente);
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", gestionfalabella.IdAseguradora);
            return View(gestionfalabella);
        }

        //
        // GET: /Gestion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GestionFalabella gestionfalabella = db.GestionFalabella.Find(id);
            if (gestionfalabella == null)
            {
                return HttpNotFound();
            }
            return View(gestionfalabella);
        }

        //
        // POST: /Gestion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GestionFalabella gestionfalabella = db.GestionFalabella.Find(id);
            db.GestionFalabella.Remove(gestionfalabella);
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