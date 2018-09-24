using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinalProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "GetAllSearch",
               url: "{controller}s/{search}/{action}",
               defaults: new { controller = "user", search = @"\w+", action = "GetAll", httpMethod = new HttpMethodConstraint("POST") });

            routes.MapRoute(
                name: "GetAll",
                url: "{controller}s/{action}",
                defaults: new { controller = "user", action = "GetAll" });

            routes.MapRoute(
                name: "Create",
                url: "{action}-{controller}",
                defaults: new { controller = "user", action = "create" },
                constraints: new { action = "create" });

            routes.MapRoute(
                name: "get",
                url: "{controller}/{id}/{action}",
                defaults: new { controller = "User", id = "1", action = "Get" },
                constraints: new { id = @"\d+", });

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            

           



        }
    }
}
