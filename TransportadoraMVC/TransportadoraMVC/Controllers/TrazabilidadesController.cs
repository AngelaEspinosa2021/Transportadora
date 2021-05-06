using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.Models;

namespace TransportadoraMVC.Controllers
{
    public class TrazabilidadesController : Controller
    {
        private TransportadoraEntities db = new TransportadoraEntities();

        // GET: Trazabilidades
        public ActionResult Index()
        {
            var trazabilidad = db.Trazabilidad.Include(t => t.Embarque);
            return View(trazabilidad.ToList());
        }

        // GET: Trazabilidades/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trazabilidad trazabilidad = db.Trazabilidad.Find(id);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            return View(trazabilidad);
        }

        // GET: Trazabilidades/Create
        public ActionResult Create()
        {
            ViewBag.IdEmbarque = new SelectList(db.Embarque, "Id", "Direccion");
            return View();
        }

        // POST: Trazabilidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create(Trazabilidad trazabilidad)
        {
            if (trazabilidad != null)
            {
                db.Trazabilidad.Add(trazabilidad);
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

                
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Trazabilidades/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trazabilidad trazabilidad = db.Trazabilidad.Find(id);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmbarque = new SelectList(db.Embarque, "Id", "Direccion", trazabilidad.IdEmbarque);
            return View(trazabilidad);
        }

        // POST: Trazabilidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoOperacion,PaisOrigen,CiudadOrigen,PaisDestino,CiudadDesstino,Kilos,Teus,IdEmbarque")] Trazabilidad trazabilidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trazabilidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmbarque = new SelectList(db.Embarque, "Id", "Direccion", trazabilidad.IdEmbarque);
            return View(trazabilidad);
        }

        // GET: Trazabilidades/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trazabilidad trazabilidad = db.Trazabilidad.Find(id);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            return View(trazabilidad);
        }

        // POST: Trazabilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Trazabilidad trazabilidad = db.Trazabilidad.Find(id);
            db.Trazabilidad.Remove(trazabilidad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
