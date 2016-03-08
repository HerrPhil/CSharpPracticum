using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DealerOrders
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Upload",
                url: "Order/BulkUpload",
                defaults: new { controller = "BulkUpload", action = "Index" }
            );

            routes.MapRoute(
                name: "ModelOptions",
                url: "Order/GetOptions/{modelId}",
                defaults: new { controller = "Order", action = "GetOptions" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
