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
            int Id = Int32.Parse(Session["UserId"].ToString());
           var nombre = db.Agente.Where(x=>x.IdAgente==Id).SingleOrDefault();
            var Aseguradora = db.Agente.Where(x => x.IdAgente == Id).Select(dto => dto.Aseguradora).SingleOrDefault();//tomamos solo la primera aseguradora del agente      
            ViewBag.IdAseguradora = nombre.IdAseguradora;
            ViewBag.IdAgente = nombre.IdAgente;
            ViewBag.NombreAgente = nombre.NombreAgente;
            ViewBag.NombreAseguradora = Aseguradora.NombreAseguradora;
            return View();
        }
        public ActionResult ProductosPorCliente(string IdGestion)// metodo que permite reflejar los productos existente al cliente y poder insertar mas
        {
            int id=Int32.Parse(IdGestion);
            GestionFalabella userGv = db.GestionFalabella.Where(x=>x.IdGestion==id).SingleOrDefault();
            IEnumerable<Productos> prods = userGv.Productos;
            IEnumerable<Productos> productos = db.Productos.Where(x => x.IdAseguradora == userGv.IdAseguradora);// tomamos los productos unicamente de la aseguradora asginada al agente
            var selecListProds = productos.Select(prod => new SelectListItem
            {
                Value = prod.IdProducto + "-" + prod.NombreProducto + "-" + prod.NombreProducto.ToLower(),
                Text = prod.NombreProducto
            });
            ViewBag.Id_Prod = selecListProds;
            ViewBag.NombreCliente = userGv.NombreCliente;
            ViewBag.IdGestion = IdGestion;
            return View(prods.ToList());
        }
        public ActionResult AgregarProductos(FormCollection formCollection)// metodo que permite insertar productos existentes al cliente
        {
            if (Request != null)
            {
                string IdGestion = Request["IdGestion"];
                string strProds = Request["Id_Prod"];
                string[] lstProds = strProds.Split(',');
                int id = Int32.Parse(IdGestion);
                GestionFalabella GestionF = db.GestionFalabella.Find(id);
                List<Productos> prodsAge = GestionF.Productos.ToList();
                foreach (string strProdss in lstProds)
                {
                    string strIdRol = strProdss.Split('-').FirstOrDefault();
                    int idPRod = 0;
                    Int32.TryParse(strIdRol, out idPRod);
                    if (idPRod != 0)
                    {
                        Productos prodAdd = db.Productos.Find(idPRod);
                        if (prodAdd != null)
                        {
                            if (!prodsAge.Any(rl => rl.IdProducto == prodAdd.IdProducto))
                                GestionF.Productos.Add(prodAdd);
                        }
                    }
                }
                db.SaveChanges();
                return RedirectToAction("ProductosPorCliente", new
                {
                    IdGestion = IdGestion
                });

            }
            return HttpNotFound("No se encontró información!");
           
        }
        //
        // POST: /Gestion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GestionFalabella gestionfalabella,FormCollection frm)
        {
           GestionFalabella gestion = new GestionFalabella();
            var idAseguradora = Request["IdAseguradora"];
            var idagente = Request["IdAgente"];
            if (ModelState.IsValid)
            {
                gestion.IdAseguradora = Int32.Parse(idAseguradora);
                gestion.IdAgente = Int32.Parse(idagente);
                gestion.NombreCliente = gestionfalabella.NombreCliente;
                gestion.Telefono = gestionfalabella.Telefono;
                gestion.Direccion = gestionfalabella.Direccion;
                gestion.Cedula = gestionfalabella.Cedula;
                db.GestionFalabella.Add(gestion);
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