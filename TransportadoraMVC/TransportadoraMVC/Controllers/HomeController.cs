using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.Models;

namespace TransportadoraMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string txtUsuario, string txtPassword)
        {
            //using (TransportadoraEntities db = new TransportadoraEntities())
            //{
            //    var listaUsuario = (from m in db.Usuario
            //                        where m.Correo == txtUsuario && m.Contraseña == txtPassword
            //                        select m).ToList();
            //    if (listaUsuario.Count() > 0)
            //    {
            //        Usuario User = listaUsuario.First();
            //        Session["User"] = User;
            //        return View(listaUsuario);
            //    }
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}