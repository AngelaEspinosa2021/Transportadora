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

namespace TransportadoraMVC.Controllers
{
    public class TrazabilidadesController : Controller
    {
        TrazabilidadReference.ServicioTrazabilidadClient cliente = new TrazabilidadReference.ServicioTrazabilidadClient();

        // GET: Trazabilidades
        public ActionResult Index()
        {            
            return View(cliente.ListarTrazabilidades());
        }

        public string Listar(long? id)
        {
            var trazabilidad = cliente.ListarTrazabilidades();
            //var trazabilidad = (from p in cliente.Trazabilidad
            //                    where p.IdEmbarque==id
            //                select p).ToList();

            return Newtonsoft.Json.JsonConvert.SerializeObject(trazabilidad,
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
            Trazabilidad trazabilidad = cliente.BuscarTrazabilidad(id.Value);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            return View(trazabilidad);
        }

        // GET: Trazabilidades/Create
        public ActionResult Create()
        {
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
                cliente.AgregarTrazabilidad(trazabilidad);
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
            Trazabilidad trazabilidad = cliente.BuscarTrazabilidad(id.Value);
            if (trazabilidad == null)
            {
                return HttpNotFound();
            }
            
            return View(trazabilidad);
        }

      
        // POST: Trazabilidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trazabilidad trazabilidad)
        {
            if (trazabilidad != null)
            {
                cliente.EditarTrazabilidad(trazabilidad.Id, trazabilidad);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Trazabilidades/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trazabilidad trazabilidad = cliente.BuscarTrazabilidad(id.Value);
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
            cliente.ConfirmarTraza(id.Value);
            return RedirectToAction("Index");
        }
        public string Eliminar(long? id)
        {
            cliente.EliminarTraza(id.Value);
            return null;
        }

        
    }
}
