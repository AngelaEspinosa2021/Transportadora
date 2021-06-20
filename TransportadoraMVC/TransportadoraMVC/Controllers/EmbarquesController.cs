using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.EmbarqueReference;

namespace TransportadoraMVC.Controllers
{
    public class EmbarquesController : Controller
    {
        EmbarqueReference.EmbarqueServiceClient cliente = new EmbarqueReference.EmbarqueServiceClient();

        // GET: Embarques
        public ActionResult Index()
        {
            return View(cliente.ListarEmbarques());
        }

        public string Listar()
        {
            var embarques = cliente.ListarEmbarques();

            return Newtonsoft.Json.JsonConvert.SerializeObject(embarques,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Embarques/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embarque embarque = cliente.BuscarEmbarque(id.Value);
            if (embarque == null)
            {
                return HttpNotFound();
            }
            return View(embarque);
        }

        public string Detalle(long? id)
        {
            var detalleEmbarque = cliente.BuscarEmbarque(id.Value);

            return Newtonsoft.Json.JsonConvert.SerializeObject(detalleEmbarque,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
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
                cliente.AgregarEmbarque(embarque);
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
            Embarque embarque = cliente.BuscarEmbarque(id.Value);
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
                cliente.AgregarEmbarque(embarque);
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
            Embarque embarque = cliente.BuscarEmbarque(id.Value);
            if (embarque == null)
            {
                return HttpNotFound();
            }
            return View(embarque);
        }

        // POST: Embarques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            cliente.Confirmacion(id.Value);
            return RedirectToAction("Index");
        }

        public string Eliminar(long? id)
        {
            cliente.EliminarTrazas(id.Value);
            cliente.EliminarEmbarque(id.Value);
            return null;
        }       
    }
}
