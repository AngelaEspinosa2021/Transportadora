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
        MonedaReference.ServicioMonedaClient cliente = new MonedaReference.ServicioMonedaClient();

        //GET: Monedas
        //public ActionResult Index()
        //{
        //    return View(db.Moneda.ToList());
        //}

        public ActionResult Index()
        {
            return View(cliente.ListarMoneda());
        }

        public string Listar()
        {

            //var monedas = (from m in db.Moneda
            //               select m).ToList();
            var monedas = View(cliente.ListarMoneda());

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
            Moneda moneda = cliente.BuscarMoneda(id.Value);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        public string Detalle(long? id)
        {
            var detalleActividad = cliente.BuscarMoneda(id.Value);

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
                //db.Moneda.Add(moneda);
                //db.SaveChanges();
                cliente.AgregarMoneda(moneda);
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
            //Moneda moneda = db.Moneda.Find(id);
            Moneda moneda = cliente.BuscarMoneda(id.Value);
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
                //db.Entry(moneda).State = EntityState.Modified;
                //db.SaveChanges();
                cliente.EditarMoneda(moneda.Id, moneda);
                return RedirectToAction("Index");
            }
            return View(moneda);
        }

        // GET: Monedas/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Moneda moneda = cliente.BuscarMoneda(id.Value);
        //    if (moneda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(moneda);
        //}

        public string eliminar(long id)
        {
            //Moneda moneda = db.Moneda.Find(id);
            //db.Moneda.Remove(moneda);
            //db.SaveChanges();
            cliente.EliminarMoneda(id);
            return null;
        }

        // POST: Monedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //Moneda moneda = db.Moneda.Find(id);
            //db.Moneda.Remove(moneda);
            //db.SaveChanges();
            cliente.EliminarMoneda(id);
            return RedirectToAction("Index");
        }
        

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
