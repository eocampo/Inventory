using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace InventoryWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {

            //routes.MapRoute(
            //    name: "RootDefault",
            //    url: "{controller}",
            //    defaults: new { controller = "Home", action = "Index" },
            //    namespaces: new[] { "InventarioWeb.Controllers" });

            //routes.MapRoute(
            //    name: "ViewDefault",
            //    url: "{controller}/{id}",
            //    defaults: new { controller = "Home", action = "View", id = UrlParameter.Optional },
            //     namespaces: new[] { "InventarioWeb.Controllers" });
          

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "InventarioWeb.Controllers" });
        }
    }
}