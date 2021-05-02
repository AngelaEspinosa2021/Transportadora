using Newtonsoft.Json;
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
    public class ActividadController : Controller
    {
        private TransportadoraEntities db = new TransportadoraEntities();

        // GET: Actividad
        public ActionResult Index()
        {
            var actividad = db.Actividad.Include(a => a.Proceso).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(actividad.ToList());
        }

        public string Listar()
        {
            var actividades = (from a in db.Actividad
                               select a).ToList();

            return Newtonsoft.Json.JsonConvert.SerializeObject(actividades,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Actividad/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        public string Detalle(long? id)
        {
            var detalleActividad = db.Actividad.Find(id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(detalleActividad,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            ViewBag.RelacionadaCon = new SelectList(db.Proceso, "Id", "Sucursal");
            ViewBag.CreadaPor = new SelectList(db.Usuario, "Id", "Correo");
            ViewBag.AsignadaA = new SelectList(db.Usuario, "Id", "Correo");
            return View();
        }

        // POST: Actividad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreadaPor,AsignadaA,RelacionadaCon,Asunto,FechaVencimiento,Observacion,Estado,Prioridad")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Actividad.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RelacionadaCon = new SelectList(db.Proceso, "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(db.Usuario, "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(db.Usuario, "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelacionadaCon = new SelectList(db.Proceso, "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(db.Usuario, "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(db.Usuario, "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // POST: Actividad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreadaPor,AsignadaA,RelacionadaCon,Asunto,FechaVencimiento,Observacion,Estado,Prioridad")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RelacionadaCon = new SelectList(db.Proceso, "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(db.Usuario, "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(db.Usuario, "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // GET: Actividad/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        
        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Actividad actividad = db.Actividad.Find(id);
            db.Actividad.Remove(actividad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string eliminar(long id)
        {
            Actividad actividad = db.Actividad.Find(id);
            db.Actividad.Remove(actividad);
            db.SaveChanges();
            return null;
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
