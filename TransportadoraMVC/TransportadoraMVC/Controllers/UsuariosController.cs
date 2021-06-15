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
using TransportadoraMVC.UsuarioReference;



namespace TransportadoraMVC.Controllers
{
    public class UsuariosController : Controller
    {
        UsuarioReference.ServicioUsuarioClient cliente = new UsuarioReference.ServicioUsuarioClient();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(cliente.ListarUsuarios());

        }
        public string Listar()
        {
            var ListaUsuarios = cliente.ListarUsuarios();

            return Newtonsoft.Json.JsonConvert.SerializeObject(ListaUsuarios,
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
                cliente.AgregarUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
                
        // GET: Usuarios/Delete/5
        public ActionResult Delete(long? id)
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

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            cliente.ConfirmarUsuario(id.Value);
            return RedirectToAction("Index");
        }

        public string eliminar(long? id)
        {
            cliente.EliminarUsuario(id.Value);
            return null;
        }

        public string CambiarPassword(long? id, string contraseñaActual, string nuevaContraseña)
        {
            Usuario usuario = cliente.BuscarUsuario(id.Value);
            
            if (usuario != null)
            {
                cliente.CambiarPassword(id.Value, contraseñaActual, nuevaContraseña);
                var mensaje = "Cambio de Contraseña Exitoso.";
                return Newtonsoft.Json.JsonConvert.SerializeObject(mensaje);
                
            }
           
            else
            {
                return null;
            }
        }

        public ActionResult Edit(long? id)
        {
            Usuario usuario = cliente.BuscarUsuario(id.Value);
            cliente.EditarUsuario(id.Value, usuario);
            return View(usuario);
        }

    }
}
