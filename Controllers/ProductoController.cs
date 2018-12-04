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
    public class ProductoController : Controller
    {
        private SegurosEntities db = new SegurosEntities();

        //
        // GET: /Producto/

        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Aseguradora);
            return View(productos.ToList());
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id = 0)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora");
            return View();
        }

        //
        // POST: /Producto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", productos.IdAseguradora);
            return View(productos);
        }

        //
        // GET: /Producto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", productos.IdAseguradora);
            return View(productos);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAseguradora = new SelectList(db.Aseguradora, "IdAseguradora", "NombreAseguradora", productos.IdAseguradora);
            return View(productos);
        }

        //
        // GET: /Producto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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