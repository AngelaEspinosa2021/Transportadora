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
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string txtUsuario, string txtPassword)
        {
            try
            {
                using (TransportadoraEntities db = new TransportadoraEntities())
                { 
                    var listaUsuario = (from m in db.Usuario
                                            where m.Correo == txtUsuario && m.Contraseña == txtPassword
                                            select m);
                    if (listaUsuario.Count() > 0)
                    {
                        Usuario User = listaUsuario.First(); //creacion de sesion en c#
                        Session["User"] = User;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }


            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :("+ex.Message);
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return Content("1");
        }

    }
}