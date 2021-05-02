﻿using Newtonsoft.Json;
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
    public class ProcesosController : Controller
    {
        private TransportadoraEntities db = new TransportadoraEntities();

        // GET: Procesos
        public ActionResult Index()
        {
            return View(db.Proceso.ToList());
        }

        public string Listar()
        {
            var procesos = (from p in db.Proceso
                               select p).ToList();

            return Newtonsoft.Json.JsonConvert.SerializeObject(procesos,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Procesos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proceso proceso = db.Proceso.Find(id);
            if (proceso == null)
            {
                return HttpNotFound();
            }
            return View(proceso);
        }

        public string Detalle(long? id)
        {
            var detalleProceso = db.Proceso.Find(id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(detalleProceso,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Procesos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procesos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sucursal,Nombre,Estado")] Proceso proceso)
        {
            if (ModelState.IsValid)
            {
                db.Proceso.Add(proceso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proceso);
        }

        // GET: Procesos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proceso proceso = db.Proceso.Find(id);
            if (proceso == null)
            {
                return HttpNotFound();
            }
            return View(proceso);
        }

        // POST: Procesos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sucursal,Nombre,Estado")] Proceso proceso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proceso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proceso);
        }

        // GET: Procesos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proceso proceso = db.Proceso.Find(id);
            if (proceso == null)
            {
                return HttpNotFound();
            }
            return View(proceso);
        }

        // POST: Procesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Proceso proceso = db.Proceso.Find(id);
            db.Proceso.Remove(proceso);
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
