using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransportadoraMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrar(string txtUsuario, string txtPassword)
        {
            try
            {


                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :("+ex.Message);
            }
        }
    }
}