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
    public class EmbarquesController : Controller
    {
        private TransportadoraEntities db = new TransportadoraEntities();

        // GET: Embarques
        public ActionResult Index()
        {
            return View(db.Embarque.ToList());
        }

        // GET: Embarques/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embarque embarque = db.Embarque.Find(id);
            if (embarque == null)
            {
                return HttpNotFound();
            }
            return View(embarque);
        }

        // GET: Embarques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Embarques/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Direccion,Telefono,Fax,Contacto,OrdenCompra,Consignatario,ZonaAduanera,Origen,Destino,EmbarqueAereo,EmbarqueMaritimo,Contenedor,INCOTERM,Observacion")] Embarque embarque)
        {
            if (ModelState.IsValid)
            {
                db.Embarque.Add(embarque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(embarque);
        }

        // GET: Embarques/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embarque embarque = db.Embarque.Find(id);
            if (embarque == null)
            {
                return HttpNotFound();
            }
            return View(embarque);
        }

        // POST: Embarques/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Direccion,Telefono,Fax,Contacto,OrdenCompra,Consignatario,ZonaAduanera,Origen,Destino,EmbarqueAereo,EmbarqueMaritimo,Contenedor,INCOTERM,Observacion")] Embarque embarque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(embarque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(embarque);
        }

        // GET: Embarques/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embarque embarque = db.Embarque.Find(id);
            if (embarque == null)
            {
                return HttpNotFound();
            }
            return View(embarque);
        }

        // POST: Embarques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Embarque embarque = db.Embarque.Find(id);
            db.Embarque.Remove(embarque);
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
