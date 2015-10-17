using System.Web.Mvc;
using System.Web.Routing;

namespace br.com.anddo.lector.api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            

            //routes.MapRoute(
            //    name: "Product",
            //    url: "{controller}/{action}/{code}",
            //    defaults: new { controller = "Product", action = "Get", code = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}