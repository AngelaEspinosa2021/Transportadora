using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.TrazabilidadReference;
using TransportadoraMVC.EmbarqueReference;

namespace TransportadoraMVC.Controllers
{
    public class TrazabilidadesController : Controller
    {
        TrazabilidadReference.TrazabilidadServiceClient trazabilidadService = new TrazabilidadReference.TrazabilidadServiceClient();
        EmbarqueReference.EmbarqueServiceClient clienteEmb = new EmbarqueReference.EmbarqueServiceClient();

        // GET: Trazabilidades
        public ActionResult Index()
        {
          //  var traza = trazabilidadService.Trazabilidad.Include(t => t.Embarque).ToList().FirstOrDefault();
            return View(trazabilidadService);
        }

        public string Listar(long? id)
        {
            var trazas = trazabilidadService.Listar(id.Value);

            return JsonConvert.SerializeObject(trazas,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Trazabilidades/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trazabilidad = trazabilidadService.BuscarTraza(id.Value);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            return View(trazabilidad);
        }

        // GET: Trazabilidades/Create
        public ActionResult Create()
        {
            ViewBag.IdEmbarque = new SelectList(clienteEmb.ListarEmbarques(), "Id", "Direccion");
            return View();
        }

        // POST: Trazabilidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create(TrazabilidadReference.Trazabilidad trazabilidad)
        {
            if (trazabilidad != null)
            {
                trazabilidadService.AgregarTraza(trazabilidad);
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
            TrazabilidadReference.Trazabilidad trazabilidad = trazabilidadService.BuscarTraza(id.Value);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmbarque = new SelectList(clienteEmb.ListarEmbarques(), "Id", "Direccion", trazabilidad.IdEmbarque);
            return View(trazabilidad);
        }

      
        // POST: Trazabilidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoOperacion,PaisOrigen,CiudadOrigen,PaisDestino,CiudadDestino,Kilos,Teus,IdEmbarque")] TrazabilidadReference.Trazabilidad trazabilidad)
        {
            if (ModelState.IsValid)
            {
                trazabilidadService.EditarTraza(trazabilidad.Id, trazabilidad);
                return RedirectToAction("Index");
            }
            ViewBag.IdEmbarque = new SelectList(clienteEmb.ListarEmbarques(), "Id", "Direccion", trazabilidad.IdEmbarque);
            return View(trazabilidad);
        }

        // GET: Trazabilidades/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrazabilidadReference.Trazabilidad trazabilidad = trazabilidadService.BuscarTraza(id.Value);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            return View(trazabilidad);
        }

        // POST: Trazabilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            trazabilidadService.Confirmacion(id.Value);
            return RedirectToAction("Index");
        }
        public string Eliminar(long? id)
        {
            trazabilidadService.EliminarTraza(id.Value);
            return null;
        }
    }
}
