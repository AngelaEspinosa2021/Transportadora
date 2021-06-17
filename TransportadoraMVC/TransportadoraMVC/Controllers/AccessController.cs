using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.Models;

namespace TransportadoraMVC.Controllers
{
    public class AccessController : Controller
    {
        UsuarioReference.ServicioUsuarioClient cliente = new UsuarioReference.ServicioUsuarioClient();
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string txtUsuario, string txtPassword)
        {
            try
            {
                var usuario = cliente.ValidarUsuario(txtUsuario,txtPassword);

                if (usuario != null)
                {
                    Session["User"] = usuario;
                    return Content("1");
                }
                else
                {
                    return Content("Usuario Invalido");
                }             
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return Content("1");
        }
    }
}