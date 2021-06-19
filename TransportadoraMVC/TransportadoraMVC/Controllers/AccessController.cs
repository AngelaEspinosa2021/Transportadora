using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.AccessReference;


namespace TransportadoraMVC.Controllers
{
    public class AccessController : Controller
    {
        AccessReference.AccessServiceClient cliente = new AccessReference.AccessServiceClient();
       
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string txtUsuario, string txtPassword)
        {
            try
            {
                var usuario = (Usuario)cliente.ValidarUsuario(txtUsuario, txtPassword);
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