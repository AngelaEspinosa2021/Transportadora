using System.Web;
using System.Web.Mvc;

namespace TransportadoraMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerifySession()); // asi damos de alta a nuestro filtro
        }
    }
}
