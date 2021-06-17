using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TransportadoraMVC.ReferenceUsuario;

namespace TransportadoraMVC.Controllers
{
    public class UsuariosController : Controller
    {
        ReferenceUsuario.ServiceUsuarioClient cliente = new ReferenceUsuario.ServiceUsuarioClient();
        //private TransportadoraEntities db = new TransportadoraEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            //var usuarios = (from m in db.Usuario select m).ToList();
            return View(cliente.ListarUsuario());
        }
        public string Listar()
        {
            var usuarios = View(cliente.ListarUsuario());

            return Newtonsoft.Json.JsonConvert.SerializeObject(usuarios,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }
        
        
        // GET: Usuarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = cliente.BuscarUsuario(id.Value);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public string Detalle(long? id)
        {
            var detalleUsuario = cliente.BuscarUsuario(id.Value);

            return Newtonsoft.Json.JsonConvert.SerializeObject(detalleUsuario,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Correo,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //db.Usuario.Add(usuario);
                //db.SaveChanges();
                cliente.AgregarUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
                
        // GET: Usuarios/Delete/5
        /*public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }*/

        // POST: Usuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //Usuario usuario = db.Usuario.Find(id);
            //db.Usuario.Remove(usuario);
            //db.SaveChanges();
            cliente.EliminarUsuario(id);
            return RedirectToAction("Index");
        }

        public string eliminar(long id)
        {
            //Usuario usuario = db.Usuario.Find(id);
            //db.Usuario.Remove(usuario);
            //db.SaveChanges();
            cliente.EliminarUsuario(id);
            return null;
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        public string CambiarPassword(long? id, string contraseñaActual, string nuevaContraseña)
        {
            Usuario usuario = cliente.BuscarUsuario(id.Value);

            if (usuario != null)
            {
                if (usuario.Contraseña == contraseñaActual)
                {
                    //usuario.Contraseña = nuevaContraseña;
                    //db.SaveChanges();
                    cliente.CambiarPassword(id.Value, contraseñaActual, nuevaContraseña);
                    var mensaje = "Cambio de Contraseña Exitoso.";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(mensaje);
                }

                return null;

            }
            else
            {
                return null;
            }
        }

        public ActionResult Edit(long id)
        {
            Usuario usuario = db.Usuario.Find(id);
            return View(usuario);
        }

    }
}
