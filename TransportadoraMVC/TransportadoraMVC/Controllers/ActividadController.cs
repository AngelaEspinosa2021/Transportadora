using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.ActividadReference;
using TransportadoraMVC.ProcesoReference;
using TransportadoraMVC.UsuarioReference;

namespace TransportadoraMVC.Controllers
{
    public class ActividadController : Controller
    {
        ActividadReference.ActividadServiceClient clienteActividad = new ActividadReference.ActividadServiceClient();
        ProcesoReference.ProcesoServiceClient clienteProceso = new ProcesoReference.ProcesoServiceClient();
        UsuarioReference.UsuarioServiceClient clienteUsuario = new UsuarioReference.UsuarioServiceClient();
        // GET: Actividad
        public ActionResult Index()
        {
            //var actividad = clienteActividad.ListarActividades().Include(a => a.Proceso).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(clienteActividad.ListarActividades());
        }

        public string Listar()
        {
            var actividades = clienteActividad.ListarActividades();

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
            ActividadReference.Actividad actividad = clienteActividad.BuscarActividad(id.Value);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        public string Detalle(long? id)
        {
            var detalleActividad = clienteActividad.BuscarActividad(id.Value);

            return Newtonsoft.Json.JsonConvert.SerializeObject(detalleActividad,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            ViewBag.RelacionadaCon = new SelectList(clienteProceso.ListarProcesos(), "Id", "Sucursal");
            ViewBag.CreadaPor = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo");
            ViewBag.AsignadaA = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo");
            return View();
        }

        // POST: Actividad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreadaPor,AsignadaA,RelacionadaCon,Asunto,FechaVencimiento,Observacion,Estado,Prioridad")] ActividadReference.Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                clienteActividad.AgregarActividad(actividad);
                return RedirectToAction("Index");
            }

            ViewBag.RelacionadaCon = new SelectList(clienteProceso.ListarProcesos(), "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadReference.Actividad actividad = clienteActividad.BuscarActividad(id.Value);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelacionadaCon = new SelectList(clienteProceso.ListarProcesos(), "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // POST: Actividad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreadaPor,AsignadaA,RelacionadaCon,Asunto,FechaVencimiento,Observacion,Estado,Prioridad")] ActividadReference.Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                clienteActividad.EditarActividad(actividad.Id, actividad);
                return RedirectToAction("Index");
            }
            ViewBag.RelacionadaCon = new SelectList(clienteProceso.ListarProcesos(), "Id", "Sucursal", actividad.RelacionadaCon);
            ViewBag.CreadaPor = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo", actividad.CreadaPor);
            ViewBag.AsignadaA = new SelectList(clienteUsuario.ListarUsuarios(), "Id", "Correo", actividad.AsignadaA);
            return View(actividad);
        }

        // GET: Actividad/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadReference.Actividad actividad = clienteActividad.BuscarActividad(id.Value);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        
        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            clienteActividad.Confirmacion(id.Value);
            return RedirectToAction("Index");
        }

        public string eliminar(long? id)
        {
            clienteActividad.EliminarActividad(id.Value);
            return null;
        }
    }
}
