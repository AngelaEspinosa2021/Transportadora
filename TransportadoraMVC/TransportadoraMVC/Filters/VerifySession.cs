using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportadoraMVC.Controllers;
using TransportadoraMVC.Models;

namespace TransportadoraMVC.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var User = (Usuario)HttpContext.Current.Session["User"]; // se evalua la sesion

            if(User == null) // se evalua si es null
            {
                if (filterContext.Controller is AccessController == false) // y ademas si el controller al que vamos es diferente a AccessController
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); // nos manda al Login.
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true) 
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); 
                }
            }

            base.OnActionExecuting(filterContext);
        }

    }
}