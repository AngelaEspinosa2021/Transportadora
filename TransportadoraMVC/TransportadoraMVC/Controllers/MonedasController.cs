using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.MonedaReference;

namespace TransportadoraMVC.Controllers
{
    public class MonedasController : Controller
    {
        MonedaReference.MonedaServiceClient clienteMoneda = new MonedaReference.MonedaServiceClient();

        // GET: Monedas
        public ActionResult Index()
        {
            return View(clienteMoneda.ListarMonedas());
        }

        public string Listar()
        {
            var monedas = clienteMoneda.ListarMonedas();

            return Newtonsoft.Json.JsonConvert.SerializeObject(monedas,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Monedas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda moneda = clienteMoneda.BuscarMoneda(id.Value);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        public string Detalle(long? id)
        {
            var detalleActividad = clienteMoneda.BuscarMoneda(id.Value);

            return Newtonsoft.Json.JsonConvert.SerializeObject(detalleActividad,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Monedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monedas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Codigo,Valor,Fecha,Descripcion")] Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                clienteMoneda.AgregarMoneda(moneda);
                return RedirectToAction("Index");
            }

            return View(moneda);
        }

        // GET: Monedas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda moneda = clienteMoneda.BuscarMoneda(id.Value);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        // POST: Monedas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Codigo,Valor,Fecha,Descripcion")] Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                clienteMoneda.EditarMoneda(moneda.Id, moneda);
                return RedirectToAction("Index");
            }
            return View(moneda);
        }

        // GET: Monedas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda moneda = clienteMoneda.BuscarMoneda(id.Value);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        // POST: Monedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            clienteMoneda.Confirmacion(id.Value);
            return RedirectToAction("Index");
        }

        public string eliminar(long? id)
        {
            clienteMoneda.EliminarMoneda(id.Value);
            return null;
        }
    }
}
