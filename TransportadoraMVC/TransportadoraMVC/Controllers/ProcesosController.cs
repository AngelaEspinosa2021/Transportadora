using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.ProcesoReference;

namespace TransportadoraMVC.Controllers
{
    public class ProcesosController : Controller
    {
        ProcesoReference.ProcesoServiceClient clienteProceso = new ProcesoReference.ProcesoServiceClient();

        // GET: Procesos
        public ActionResult Index()
        {
            return View(clienteProceso.ListarProcesos());
        }

        public string Listar()
        {
            var procesos = clienteProceso.ListarProcesos();

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
            Proceso proceso = clienteProceso.BuscarProceso(id.Value);
            if (proceso == null)
            {
                return HttpNotFound();
            }
            return View(proceso);
        }

        public string Detalle(long? id)
        {
            var detalleProceso = clienteProceso.BuscarProceso(id.Value);

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
                clienteProceso.AgregarProceso(proceso);
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
            Proceso proceso = clienteProceso.BuscarProceso(id.Value);
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
                clienteProceso.EditarProceso(proceso.Id, proceso);
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
            Proceso proceso = clienteProceso.BuscarProceso(id.Value);
            if (proceso == null)
            {
                return HttpNotFound();
            }
            return View(proceso);
        }

        // POST: Procesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            clienteProceso.Confirmacion(id.Value);
            return RedirectToAction("Index");
        }

        public string eliminar(long? id)
        {
            clienteProceso.EliminarProceso(id.Value);
            return null;
        }
    }
}
