using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.ReferenceActividad;
using TransportadoraMVC.ReferenceProceso;
using TransportadoraMVC.ReferenceUsuario;


namespace TransportadoraMVC.Controllers
{
    public class ActividadController : Controller
    {
        ReferenceActividad.ServiceActividadClient cliente = new ReferenceActividad.ServiceActividadClient();
        ReferenceProceso.ServiceProcesoClient clientePro = new ReferenceProceso.ServiceProcesoClient();
        ReferenceUsuario.ServiceUsuarioClient clienteUsu = new ReferenceUsuario.ServiceUsuarioClient();

        // GET: Actividad
        public ActionResult Index()
        {
            //var actividad = db.Actividad.Include(a => a.Proceso).Include(a => a.Usuario).Include(a => a.Usuario1);
            //return View(actividad.ToList());
            return View(cliente.ListarActividad());

        }

        public string Listar()
        {

            //var actividades = (from a in db.Actividad
            //                   select a).ToList();

            var actividad = View(cliente.ListarActividad());

            return Newtonsoft.Json.JsonConvert.SerializeObject(actividad,
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
            ReferenceActividad.Actividad actividad = cliente.BuscarActividad(id.Value);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        public string Detalle(long? id)
        {
            var detalleActividad = cliente.BuscarActividad(id.Value);

            return Newtonsoft.Json.JsonConvert.SerializeObject(detalleActividad,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            ViewBag.RelacionadaCon = new SelectList(clientePro.ListarProceso(), "Id", "Sucursal");
            ViewBag.CreadaPor = new SelectList(clienteUsu.ListarUsuario(), "Id", "Correo");
            ViewBag.AsignadaA = new SelectList(clienteUsu.ListarUsuario(), "Id", "Correo");
            return View();
        }

        // POST: Actividad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreadaPor,AsignadaA,RelacionadaCon,Asunto,FechaVencimiento,Observacion,Estado,Prioridad")] ReferenceActividad.Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                //db.Actividad.Add(actividad);
                //db.SaveChanges();
                cliente.AgregarActividad(actividad);
                return RedirectToAction("Index");
            }

            ViewBag.RelacionadaCon = new SelectList(clientePro.ListarProceso(), "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(clienteUsu.ListarUsuario(), "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(clienteUsu.ListarUsuario(), "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenceActividad.Actividad actividad = cliente.BuscarActividad(id.Value);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelacionadaCon = new SelectList(clientePro.ListarProceso(), "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(clienteUsu.ListarUsuario(), "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(clienteUsu.ListarUsuario(), "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // POST: Actividad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreadaPor,AsignadaA,RelacionadaCon,Asunto,FechaVencimiento,Observacion,Estado,Prioridad")] ReferenceActividad.Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(actividad).State = EntityState.Modified;
                //db.SaveChanges();
                cliente.EditarActividad(actividad.Id, actividad);
                return RedirectToAction("Index");
            }
            //ViewBag.RelacionadaCon = new SelectList(db.Proceso, "Id", "Sucursal", actividad.RelacionadaCon);
            //ViewBag.CreadaPor = new SelectList(db.Usuario, "Id", "Correo", actividad.CreadaPor);
            //ViewBag.AsignadaA = new SelectList(db.Usuario, "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // GET: Actividad/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Actividad actividad = db.Actividad.Find(id);
        //    if (actividad == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(actividad);
        //}


        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //Actividad actividad = db.Actividad.Find(id);
            //db.Actividad.Remove(actividad);
            //db.SaveChanges();
            cliente.EliminarActividad(id);
            return RedirectToAction("Index");
        }

        public string eliminar(long id)
        {
            //Actividad actividad = db.Actividad.Find(id);
            //db.Actividad.Remove(actividad);
            //db.SaveChanges();
            cliente.EliminarActividad(id);
            return null;
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