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
    public class AseguradoraController : Controller
    {
        private SegurosEntities db = new SegurosEntities();

        //
        // GET: /Aseguradora/

        public ActionResult Index()
        {
            return View(db.Aseguradora.ToList());
        }

        //
        // GET: /Aseguradora/Details/5

        public ActionResult Details(int id = 0)
        {
            Aseguradora aseguradora = db.Aseguradora.Find(id);
            if (aseguradora == null)
            {
                return HttpNotFound();
            }
            return View(aseguradora);
        }

        //
        // GET: /Aseguradora/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Aseguradora/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aseguradora aseguradora)
        {
            if (ModelState.IsValid)
            {
                db.Aseguradora.Add(aseguradora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aseguradora);
        }

        //
        // GET: /Aseguradora/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Aseguradora aseguradora = db.Aseguradora.Find(id);
            if (aseguradora == null)
            {
                return HttpNotFound();
            }
            return View(aseguradora);
        }

        //
        // POST: /Aseguradora/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aseguradora aseguradora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aseguradora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aseguradora);
        }

        //
        // GET: /Aseguradora/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Aseguradora aseguradora = db.Aseguradora.Find(id);
            if (aseguradora == null)
            {
                return HttpNotFound();
            }
            return View(aseguradora);
        }

        //
        // POST: /Aseguradora/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aseguradora aseguradora = db.Aseguradora.Find(id);
            db.Aseguradora.Remove(aseguradora);
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